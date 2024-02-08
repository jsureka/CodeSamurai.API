using System.ComponentModel.DataAnnotations;

namespace CodeSamurai.API.Core.Domains
{
    public abstract partial class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
