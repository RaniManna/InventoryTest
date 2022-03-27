using Inventory.API.DTOs.Result;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        [NonAction]
        protected static IActionResult SendResponse<T>(T data, string message, int code = 200)
        {
            return new ApiResult<SuccessResult<T>>(new SuccessResult<T> { Data = data, Message = message }, code);
        }

        [NonAction]
        protected static IActionResult SendSuccess<T>(string message, int code = 200)
        {
            return SendResponse<EmptyResult>(null, message, code);
        }

        [NonAction]
        protected static IActionResult SendError(string message, int code = 400)
        {
            return new ApiResult<FailedResult>(new FailedResult() { Message = message }, code);
        }

    }
}
