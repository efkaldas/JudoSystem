using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionFilters.Filters
{
    public class ValidateEntityExists<T> : IActionFilter where T : class, IEntity
    {
        private readonly JudoDbContext db;

        public ValidateEntityExists(JudoDbContext context)
        {
            db = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int id = 0;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (int)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult(new ErrorDetails(ErrorDetails.HTTP_STATUS_BAD_REQUEST_CONST, "Entity with this id not found."));
                return;
            }

            var entity = db.Set<T>().SingleOrDefault(x => x.Id.Equals(id));
            if (entity == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
