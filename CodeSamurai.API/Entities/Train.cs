using CodeSamurai.API.Core.Domains;

namespace CodeSamurai.API.Entities
{
    public class Train : BaseEntity
    {
        public required string Name { get; set; }

        public int Capacity { get; set; }

        public IList<Stops>? Stops { get; set; }
    }
}
