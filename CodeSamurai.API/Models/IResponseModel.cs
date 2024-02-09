namespace CodeSamurai.API.Models
{
    public interface IResponseModel<T> where T : class
    {
        T Data { get; set; }
        string Message { get; set; }
        bool Success { get; set; }
    }
}
