using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiResource.Resources;

namespace WebApiResource.Filters;

public class ResourceErrorFilter : ExceptionFilterAttribute
{
    private readonly MessageResourceContext _messageResourceContext;

    public ResourceErrorFilter(MessageResourceContext messageResourceContext)
    {
        _messageResourceContext = messageResourceContext;
    }

    public override void OnException(ExceptionContext context)
    {

        if (!context.ExceptionHandled)
        {
            int statusCode = GetStatusCodeFromException(context.Exception);
            string errorMessage = _messageResourceContext.GetMessage(statusCode.ToString());

            var returnPattern = new
            {
                title = "One or more errors occurred.",
                status = statusCode,
                message = errorMessage,
            };

            context.Result = new ObjectResult(returnPattern) { StatusCode = statusCode };

            context.ExceptionHandled = true;
        }
    }


    private static int GetStatusCodeFromException(Exception exception)
    {
        if (exception is HttpRequestException httpRequestException)
        {
            if (httpRequestException.StatusCode.HasValue)
            {
                return (int)httpRequestException.StatusCode.Value;
            }
        }
        return 500;
    }
}

