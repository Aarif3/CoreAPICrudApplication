using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CRUDCoreAPI
{

    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _loger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> loger)=>
            _loger = loger;


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex,ex.Message);
                if (context.Response.StatusCode == 200)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsync("Page Not Found");

                }
                //context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //await context.Response.WriteAsync("Page Not Found");
            }
        }
    }
}
