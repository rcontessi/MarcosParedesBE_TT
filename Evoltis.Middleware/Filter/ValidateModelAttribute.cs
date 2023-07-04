using System;
using Evoltis.Middleware.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Evoltis.Middleware.Filter
{
    public class ValidateModelAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var modelError = new ComponentError().FromModelState(context.ModelState);
                throw new BasicExceptions.BadRequestException(modelError.Errors);
            }
        }
    }
}

