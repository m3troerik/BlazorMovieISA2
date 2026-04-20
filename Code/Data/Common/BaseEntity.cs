using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime? ValidFrom { get; set; }
        public virtual DateTime? ValidTo { get; set; }
        [Timestamp] public virtual byte[] Timestamp { get; set; } = [];
    }
}
