using System;
using System.Net;
using Evoltis.Middleware.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static Evoltis.Middleware.Exceptions.BasicExceptions;

namespace Evoltis.Middleware
{
    public static class ExceptionsMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is NotFoundException)
                        {
                            var exception = (NotFoundException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is BadRequestException)
                        {
                            var exception = (BadRequestException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Errors));
                            return;
                        }

                        if (contextFeature.Error is ConflictException)
                        {
                            var exception = (ConflictException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is PreconditionFailedException)
                        {
                            var exception = (PreconditionFailedException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is ForbiddenException)
                        {
                            var exception = (ForbiddenException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is UnauthorizedException)
                        {
                            var exception = (UnauthorizedException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is Newtonsoft.Json.JsonSerializationException)
                        {
                            var exception = (Newtonsoft.Json.JsonSerializationException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is FormatException)
                        {
                            var exception = (FormatException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is TimeOutException)
                        {
                            var exception = (TimeOutException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
                            return;
                        }

                        if (contextFeature.Error is InternalServerErrorException)
                        {
                            var exception = (InternalServerErrorException)contextFeature.Error;
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.serverError));
                            return;
                        }

                        ServerErrorModel serverError = new ServerErrorModel(contextFeature.Error);
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(serverError));

                    }
                });
            });
        }
    }
}
