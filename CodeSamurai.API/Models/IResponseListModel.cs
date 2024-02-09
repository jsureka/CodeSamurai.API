using CodeSamurai.API.Core.Framework;

namespace CodeSamurai.API.Models
{
    public interface IResponseListModel<T> where T : class
    {
        IList<T> Data { get; set; }
        string Message { get; set; }
        bool Success { get; set; }
    }
}
