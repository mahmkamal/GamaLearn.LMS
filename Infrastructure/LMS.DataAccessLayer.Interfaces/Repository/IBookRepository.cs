using GamaLearn.LMS.Models.Entites;
using GamaLearn.LMS.DataAccess.Interfaces.Repository;

namespace GamaLearn.LMS.Domain.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetAllBooks();
        void SaveBook(Book book);
        Book GetById(int id);
        void Delete(int id);
    }
}