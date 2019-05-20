using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScheduleApp.WebApi.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleApp.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHostingEnvironment hostingEnvironment)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, hostingEnvironment);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, IHostingEnvironment hostingEnvironment)
        {
            var errorResp = new ErrorResp();

            var msg = "Internal Server Error";
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (hostingEnvironment.IsDevelopment())
            {
                msg = ex.Message;
            }

            if (ex is ArgumentException)
            {
                code = HttpStatusCode.BadRequest;
                msg = ex.Message;
            }
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is MyException) code = HttpStatusCode.BadRequest;

            errorResp.SetHttpCode(code);
            errorResp.AddErrors(msg);

            var result = JsonConvert.SerializeObject(errorResp);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
