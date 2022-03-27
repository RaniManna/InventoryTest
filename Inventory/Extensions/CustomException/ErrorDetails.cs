using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Inventory.API.Extensions.CustomException
{
    public class ErrorDetails
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);

        }
    }
}