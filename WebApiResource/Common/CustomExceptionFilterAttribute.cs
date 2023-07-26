using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Resources;
using WebApiResource.Resources;

namespace WebApiResource.Filters
{
    public class ResourceExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ResourceManager _resourceManager = new(typeof(ErrorMessages));

        public override void OnException(ExceptionContext context)
        {
            var statusCode = GetHttpStatusCodeFromException(context);

            var errorMessage = GetErrorMessage(statusCode);
            context.Result = new ObjectResult(new
            {
                title = "One or more errors occurred.",
                status = statusCode,
                message = errorMessage,
            })
            {
                StatusCode = statusCode,
            };

            context.ExceptionHandled = true;
        }

        private static string GetErrorMessage(int statusCode)
        {
            string errorMessage = _resourceManager.GetString(name: $"{statusCode}");

            return string.IsNullOrEmpty(errorMessage) ? "Internal Server Error" : errorMessage;
        }

        private static int GetHttpStatusCodeFromException(ExceptionContext context)
        {
            if (context.Exception is HttpRequestException httpRequestException)
            {
                if (httpRequestException.StatusCode.HasValue)
                {
                    return (int)httpRequestException.StatusCode.Value;
                }
            }
            return 500;
        }
    }
}
