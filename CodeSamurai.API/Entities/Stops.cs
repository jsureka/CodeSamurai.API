using CodeSamurai.API.Core.Domains;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSamurai.API.Entities
{
    public class Stops : BaseEntity
    {
        [ForeignKey("Station")]
        public int StationId { get; set; }

        public string? ArrivalTime { get; set; }

        public string? DepartureTime { get; set; }

        public int Fare { get; set; }
    }
}
