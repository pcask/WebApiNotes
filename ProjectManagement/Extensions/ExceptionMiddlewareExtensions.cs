using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
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

                    var featureError = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

                    if (featureError != null)
                    {
                        httpContext.Response.StatusCode = featureError switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError("There is a problem : " + featureError);

                        await httpContext.Response.WriteAsync(new ErrorDetails()
                        {
                            Message = featureError.Message,
                            StatusCode = httpContext.Response.StatusCode,
                        }.ToString());
                    }
                });
            });
        }
    }
}
