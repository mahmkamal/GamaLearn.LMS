using AutoMapper;
using GamaLearn.LMS.Content;
using GamaLearn.LMS.DataAccess.Interfaces;
using GamaLearn.LMS.Domain.Repository;
using GamaLearn.LMS.Helper;
using GamaLearn.LMS.Models.Entites;

namespace GamaLearn.LMS.Services.Validators
{
    public class BookValidator : BookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _AutoMapper;

        public BookValidator(IUnitOfWork unitOfWork, IBookRepository bookRepository, IMapper AutoMapper) : base(unitOfWork, bookRepository,AutoMapper)
        {
            _unitOfWork = unitOfWork;
        }
        //public override void Save(Book Book)
        //{
        //    if (Book.isActive == true)
        //    {
        //        #region Validation
        //        if (!Book.email.ValidPattern(Patterns.email))
        //        {
        //            throw new Exception("Invalid Input");
        //        }
        //        if (!Book.userName.ValidPattern(Patterns.Alphanumeric))
        //        {
        //            throw new Exception("Invalid Input");
        //        }
        //        if (!Book.fullName.ValidPattern(Patterns.Alphanumeric))
        //        {
        //            throw new Exception("Invalid Input");
        //        }
        //        #endregion
        //    }
        //    return base.Save(Book);
        //}
    }
}
