namespace QuotesApiV2.Domain.Dtos
{
    public class ApiResponse
    {
        public string responseCode { get; set; } = null!;
        public string responseMessage { get; set; } = null!;
        public object data { get; set; } = null!;
    }
}
