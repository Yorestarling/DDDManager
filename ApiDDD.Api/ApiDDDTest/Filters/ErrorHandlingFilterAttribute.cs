using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ApiDDD.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            {
               
                Title= exception.Message,
                Status=(int)HttpStatusCode.InternalServerError,

            };

            context.Result = new ObjectResult(problemDetails);
            


            //if (context.Exception == null)
            //{
            //    return;
            //}
            //context.Result = new ObjectResult(new {  
            //    error =context.Exception.Message,
            //});
        }
    }
}
