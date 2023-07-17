using System.ComponentModel.DataAnnotations;

namespace GamaLearn.LMS.Models.BaseEntity
{
    public class EntityBase : IEntityBase, IEntityBase<string>
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual string? CreatedBy { get; set; }

        public virtual DateTime? UpdatedDate { get; set; }

        public virtual string? UpdatedBy { get; set; }
        public virtual bool isActive { get; set; }
    }
}
