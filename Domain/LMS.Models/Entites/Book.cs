using GamaLearn.LMS.Models.BaseEntity;
namespace GamaLearn.LMS.Models.Entites
{
    public partial class Book : EntityBase
    {
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Author { get; set; }
    }
}
