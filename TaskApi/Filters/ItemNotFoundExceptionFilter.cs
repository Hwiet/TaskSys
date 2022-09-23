using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using TaskApi.Lib.Exceptions;
using TaskAPI.Lib.Exceptions;

namespace TaskApi.Filters
{
    public class ItemNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ItemNotFoundException)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(context.Exception.Message)
                    }
                );
            }
        }
    }

    public class DuplicateItemExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is DuplicateItemException)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.Conflict)
                    {
                        Content = new StringContent(context.Exception.Message)
                    }
                );
            }
        }
    }
}