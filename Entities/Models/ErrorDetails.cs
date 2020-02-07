using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ErrorDetails
    {
        public const int HTTP_STATUS_BAD_REQUEST_CONST = 400;
        public const int HTTP_STATUS_UNAUTHORIZED_CONST = 401;
        public const int HTTP_STATUS_FORBIDDEN_CONST = 403;
        public const int HTTP_STATUS_NOT_FOUND_CONST = 404;
        public const int HTTP_STATUS_REQUEST_TIMEOUT_CONST = 408;
        public const int HTTP_STATUS_ENTITY_EXISTS_CONST = 409;

        public static readonly ErrorDetails HTTP_STATUS_BAD_REQUEST = new ErrorDetails(HTTP_STATUS_BAD_REQUEST_CONST, "Bad Request.");
        public static readonly ErrorDetails HTTP_STATUS_UNAUTHORIZED = new ErrorDetails(HTTP_STATUS_UNAUTHORIZED_CONST, "Unauthorized .");
        public static readonly ErrorDetails HTTP_STATUS_FORBIDDEN = new ErrorDetails(HTTP_STATUS_FORBIDDEN_CONST, "Forbidden.");
        public static readonly ErrorDetails HTTP_STATUS_NOT_FOUND = new ErrorDetails(HTTP_STATUS_NOT_FOUND_CONST, "Not Found.");
        public static readonly ErrorDetails HTTP_STATUS_REQUEST_TIMEOUT = new ErrorDetails(HTTP_STATUS_REQUEST_TIMEOUT_CONST, "Request Timeout.");
        public static readonly ErrorDetails HTTP_STATUS_ENTITY_EXISTS = new ErrorDetails(HTTP_STATUS_ENTITY_EXISTS_CONST, "Eintity exists.");
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorDetails()
        {
        }
        public ErrorDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
