namespace CodeSamurai.API.Models
{
    public class ResponseModel<T> : IResponseModel<T> where T : class
    {
        public T Data { get; set; }
    }
}
