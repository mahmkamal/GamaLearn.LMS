namespace GamaLearn.LMS.Models.BaseEntity
{
    public interface IEntityBase : IEntityBase<string>
    {
    }
    public interface IEntityBase<T>
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string? UpdatedBy { get; set; }
        bool isActive { get; set; }
    }
}
