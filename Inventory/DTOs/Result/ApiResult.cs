using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.DTOs.Result
{
  public class ApiResult<T> : IActionResult
  {

    private readonly T _result;
    private readonly int _code;

    public ApiResult(T result,int code)
    {
      _result = result;
      _code = code;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
      var objectResult = new ObjectResult(_result)
      {
        StatusCode = _code
      };

      await objectResult.ExecuteResultAsync(context);
    }
  }
}
