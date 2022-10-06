using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async httpContext =>
                {
                    httpContext.Response.ContentType = "application/json";

                    var exFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

                    if (exFeature != null)
                    {
                        logger.LogError("There is a problem : " + exFeature.Error);

                        await httpContext.Response.WriteAsync(new ErrorDetails()
                        {
                            Message = "Internal server error.",
                            StatusCode = StatusCodes.Status500InternalServerError,
                        }.ToString());
                    }
                });
            });
        }
    }
}
