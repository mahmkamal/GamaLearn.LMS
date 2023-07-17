using GamaLearn.LMS.DataAccess.Repository;
using GamaLearn.LMS.DataAccess.Interfaces;
using GamaLearn.LMS.Domain.Repository;
using GamaLearn.LMS.Infrastructure.Repository;
using GamaLearn.LMS.Models.Entites;

namespace GamaLearn.LMS.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LMSDbContext _dbContext;

        public UnitOfWork(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IBookRepository? _bookRepository;
        public IBookRepository bookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_dbContext));


        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task<bool> Complete()
        => await _dbContext.SaveChangesAsync() > 0;
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
