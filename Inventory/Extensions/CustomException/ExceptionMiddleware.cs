using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Inventory.API.Extensions.CustomException
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException avEx)
            {
                _logger.LogError($"A new violation exception has been thrown: {avEx.Message}");
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (ArgumentNullException anEx)
            {
                _logger.LogError($"A new  argument null exception has been thrown: {anEx.Message}");
                await HandleExceptionAsync(httpContext, anEx);
            }
            catch (ArgumentException aEx)
            {
                _logger.LogError($"A new  argument  exception has been thrown: {aEx.Message}");
                await HandleExceptionAsync(httpContext, aEx);
            }
            catch (ArithmeticException arEx)
            {
                _logger.LogError($"A new  arithmatic exception has been thrown: {arEx.Message}");
                await HandleExceptionAsync(httpContext, arEx);
            }
            catch (InvalidOperationException ioEx)
            {
                _logger.LogError($"A new  Invaild operation exception has been thrown: {ioEx.Message}");
                await HandleExceptionAsync(httpContext, ioEx);
            }
            catch (MethodAccessException maEx)
            {
                _logger.LogError($"A new  method access exception has been thrown: {maEx.Message}");
                await HandleExceptionAsync(httpContext, maEx);
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($"A new  time out exception has been thrown: {toEx.Message}");
                await HandleExceptionAsync(httpContext, toEx);
            }
            catch (RankException rEx)
            {
                _logger.LogError($"A new  rank exception has been thrown: {rEx.Message}");
                await HandleExceptionAsync(httpContext, rEx);
            }
            catch (ApplicationException apEx)
            {
                _logger.LogError($"A new  application exception has been thrown: {apEx.Message}");
                await HandleExceptionAsync(httpContext, apEx);
            }
            catch (HttpListenerException htlEx)
            {
                _logger.LogError($"A new  http  exception has been thrown: {htlEx.Message}");
                await HandleExceptionAsync(httpContext, htlEx);
            } 
            catch (HttpRequestException htrEx)
            {
                _logger.LogError($"A new  http request exception has been thrown: {htrEx.Message}");
                await HandleExceptionAsync(httpContext, htrEx);
            } 
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception.Message;
              
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}