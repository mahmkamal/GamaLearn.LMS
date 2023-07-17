using GamaLearn.LMS.DataAccess;
using GamaLearn.LMS.Domain.Repository;
using GamaLearn.LMS.Models.Entites;
using Microsoft.EntityFrameworkCore;
namespace GamaLearn.LMS.DataAccess.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly LMSDbContext _dbContext;
        public BookRepository(LMSDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveBook(Book book)
        {
            try
            {
                _dbContext.Books.Add(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                return await _dbContext.Books.Where(M => M.isActive).OrderByDescending(M => M.CreatedDate).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Book GetById(int id)
        {
            try
            {
                return _dbContext.Books.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var book = _dbContext.Books.Find(id);
                if (book != null)
                {
                    _dbContext.Books.Remove(book);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}