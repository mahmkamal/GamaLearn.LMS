using GamaLearn.LMS.Models.DTO;
using GamaLearn.LMS.Models.Entites;

namespace GamaLearn.LMS.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTOTiny>> GetAll();
        BookDTO Save(BookDTO book);
        BookDTO Get(int id);
        void Delete(int id);
    }
}