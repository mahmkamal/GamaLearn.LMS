using GamaLearn.LMS.Models.BaseEntity;
namespace GamaLearn.LMS.Models.DTO
{
    public partial class BookDTOTiny 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Author { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
