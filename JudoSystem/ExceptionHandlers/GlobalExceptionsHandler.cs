using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JudoSystem.ExceptionHandlers
{
    public class GlobalExceptionsHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public GlobalExceptionsHandler(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            try
            {
                await HandleCustomException(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Internal Server Error. {exception.Message} {exception.InnerException} {exception}"
            }.ToString());
        }
        private Task HandleCustomException(HttpContext context)
        {
            ErrorDetails temp = new ErrorDetails();

  //          context.Response.ContentType = "application/json";

            switch (context.Response.StatusCode)
            {
                case ErrorDetails.HTTP_STATUS_BAD_REQUEST_CONST:
                    temp = ErrorDetails.HTTP_STATUS_BAD_REQUEST;
                    break;
                case ErrorDetails.HTTP_STATUS_UNAUTHORIZED_CONST:
                    temp = ErrorDetails.HTTP_STATUS_UNAUTHORIZED;
                    break;
                case ErrorDetails.HTTP_STATUS_FORBIDDEN_CONST:
                    temp = ErrorDetails.HTTP_STATUS_FORBIDDEN;
                    break;
                case ErrorDetails.HTTP_STATUS_NOT_FOUND_CONST:
                    temp = ErrorDetails.HTTP_STATUS_NOT_FOUND;
                    break;
                case ErrorDetails.HTTP_STATUS_REQUEST_TIMEOUT_CONST:
                    temp = ErrorDetails.HTTP_STATUS_REQUEST_TIMEOUT;
                    break;
                default:
                    return Task.CompletedTask;
            }

            return context.Response.WriteAsync(temp.ToString());
        }
    }
}
