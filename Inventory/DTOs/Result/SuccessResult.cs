namespace Inventory.API.DTOs.Result
{
  public class SuccessResult<T>
  {
    public bool Success
    {
      get => true;
    }

    public T Data { get; set; }
    public string Message { get; set; }
  }
}
