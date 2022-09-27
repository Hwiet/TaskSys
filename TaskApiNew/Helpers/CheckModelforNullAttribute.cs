using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

// See tutorial https://www.strathweb.com/2012/10/clean-up-your-web-api-controllers-with-model-validation-and-null-check-filters/
namespace TaskApiNew.Helpers
{
    // AttributeTargets Enum: Specifies the application elements on which it is valid to apply an attribute.
    // Inherited: This named parameter specifies whether the indicated attribute can be inherited by derived classes and overriding members.
    //[AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckForNullArgumentsAttribute : ActionFilterAttribute
    {
        private Func<Dictionary<string, object>, bool> _validate;

        public CheckForNullArgumentsAttribute() : this(args => args.ContainsValue(null))
        {
        }

        public CheckForNullArgumentsAttribute(Func<Dictionary<string, object>, bool> checkCondition)
        {
            _validate = checkCondition;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (_validate(actionContext.ActionArguments))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
       HttpStatusCode.BadRequest, "The argument cannot be null");
            }
        }
    }
}