using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_LibraryAPI.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //default
            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.Path,
                Title = "An unexpected error occurred",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message
            };

            //custom exceptions
            switch (exception)
            {
                case BookNotFoundException bookNFE:
                    problemDetails.Title = "Book not found";
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Detail = bookNFE.Message;
                    break;
                case BorrowerNotFoundException borrowerNFE:
                    problemDetails.Title = "Borrower not found";
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Detail = borrowerNFE.Message;
                    break;
            }

            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}
