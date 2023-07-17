using LMS.Domain.Repository;
namespace LMS.Infrastructure.Repository
{
	public class BookRepository : IBookRepository
    {
        private readonly TaskDbContext _dbContext;
        public BookRepository(TaskDbContext dbContext) 
        {
            _dbContext = dbContext;
        }    
    }
}