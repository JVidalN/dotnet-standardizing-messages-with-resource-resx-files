using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiResource.Resources;

namespace WebApiResource.Filters
{
    public class ResourceErrorFilter : ExceptionFilterAttribute
    {
        private readonly MessageResourceContext _messageResourceContext;

        public ResourceErrorFilter(MessageResourceContext messageResourceFactory)
        {
            _messageResourceContext = messageResourceFactory;
        }

        public override void OnException(ExceptionContext context)
        {
            var statusCode = GetHttpStatusCodeFromException(context);

            var errorMessage = GetErrorMessage(statusCode);

            var returnPattern = new
            {
                title = "One or more errors occurred.",
                status = statusCode,
                message = errorMessage,
            };

            context.Result = new ObjectResult(returnPattern) { StatusCode = statusCode };

            context.ExceptionHandled = true;
        }

        private string GetErrorMessage(int statusCode)
        {
            string errorMessage = _messageResourceContext.GetMessage(statusCode.ToString());

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
