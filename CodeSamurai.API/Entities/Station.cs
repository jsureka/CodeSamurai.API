using CodeSamurai.API.Core.Domains;

namespace CodeSamurai.API.Entities
{
    public class Station : BaseEntity
    {
        public required string Name { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
