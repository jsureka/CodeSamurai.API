using CodeSamurai.API.Core.Framework;

namespace CodeSamurai.API.Models
{
    public class ResponseListModel<T>: IResponseListModel<T> where T : class
    {
        public IList<T> Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
