namespace CodeSamurai.API.Models
{
    public class ResponseModel<T> : IResponseModel<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
