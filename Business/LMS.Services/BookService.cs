using BCrypt.Net;
using GamaLearn.LMS.Services.Interfaces;
using GamaLearn.LMS.DataAccess.Interfaces;
using GamaLearn.LMS.Models.Entites;
using GamaLearn.LMS.Models.DTO;
using GamaLearn.LMS.Domain.Repository;
using AutoMapper;

namespace GamaLearn.LMS.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _AutoMapper;

        public BookService(IUnitOfWork unitOfWork, IBookRepository bookRepository, IMapper AutoMapper)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
            _AutoMapper = AutoMapper;
        }

        public BookDTO Get(int id)
        {
            return _AutoMapper.Map<BookDTO>(_bookRepository.GetById(id));
        }
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public async Task<List<BookDTOTiny>> GetAll()
        => _AutoMapper.Map<List<BookDTOTiny>>(await _bookRepository.GetAllBooks());


        public BookDTO Save(BookDTO Book)
        {
            try
            {
                DateTime SysDate = DateTime.Now;
                var original = Book.Id == 0 ? null : _bookRepository.GetById(Book.Id);
                bool IsNew = original == null;
                if (!IsNew && original != null && original.isActive)
                {
                    original.UpdatedDate = SysDate;
                    original.UpdatedBy = Book.CreatedBy;
                }
                if (IsNew)
                {
                    original = new Book()
                    {
                        CreatedBy = "Mahmoud",
                       // Password = BCrypt.Net.BCrypt.HashPassword(Book.Password), this hashing in case of ave a password in our model
                        CreatedDate = SysDate,
                        isActive = true
                    };
                    _bookRepository.SaveBook(original);
                }
                if (IsNew || Book.isActive)
                {
                    original.Name = Book.Name;
                    original.Department = Book.Department;
                    original.Author = Book.Author;
                    //if (Book.Password != null)
                    //    original.Password = BCrypt.Net.BCrypt.HashPassword(Book.Password); this hashing in case of ave a password in our model
                }
                else
                {
                    original.isActive = false; // in case of using soft delete 
                }
                _unitOfWork.Commit();
                return _AutoMapper.Map<BookDTO>(original);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}