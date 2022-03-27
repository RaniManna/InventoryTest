namespace Inventory.API.DTOs.Result
{
  public class FailedResult
  {
    public bool Success
    {
      get => false;
    }

    public string Message { get; set; }
  }
}
