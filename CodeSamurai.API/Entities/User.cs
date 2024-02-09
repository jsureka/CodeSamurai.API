using CodeSamurai.API.Core.Domains;

namespace CodeSamurai.API.Entities
{
    public class User : BaseEntity
    {
        public int User_id { get; set; }
        public required string Name { get; set; }
        public required int Balance { get; set; }
    }
}
