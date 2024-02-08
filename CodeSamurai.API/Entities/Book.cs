using CodeSamurai.API.Core.Domains;
using CodeSamurai.API.Core.Framework;

namespace CodeSamurai.API.Entities
{
    public class Book : BaseEntity
    {
        public required string Title { get; set; }
        public string? Author { get; set; }
        public required string Genre { get; set; }
        public double Price { get; set; }
    }
}
