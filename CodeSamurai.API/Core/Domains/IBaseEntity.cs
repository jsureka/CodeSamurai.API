
using System.ComponentModel.DataAnnotations;

namespace CodeSamurai.API.Core.Domains
{
    public interface IBaseEntity
    {

        [Key]
        public int Id { get; set; }
    }
}