
using GamaLearn.LMS.Domain.Repository;
namespace GamaLearn.LMS.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository bookRepository { get; }
        void Commit();
        Task<bool> Complete();
    }
}

