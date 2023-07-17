using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Xunit.Sdk;
using GamaLearn.LMS.DataAccess.Interfaces;
using GamaLearn.LMS.Domain.Repository;
using GamaLearn.LMS.Services.Interfaces;
using AutoMapper;
using System.Data;
using GamaLearn.LMS.Models.DTO;
using GamaLearn.LMS.Models.Entites;
using GamaLearn.LMS.Services;

namespace GamaLearn.LMS.UnitTets
{
    [TestClass]
    public class BooksUnitTest
    {
        private readonly Mock<IUnitOfWork> _unitofwork;
        private readonly Mock<IBookRepository> _bookRepository;
        private readonly Mock<IBookService> _bookService;
        private readonly IMapper _mapMock;
        public BooksUnitTest()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<BookDTO, Book>().ReverseMap();
                cfg.CreateMap<BookDTOTiny, Book>().ReverseMap();

            });
            _mapMock = config.CreateMapper();
            _unitofwork = new Mock<IUnitOfWork>();
            _bookRepository = new Mock<IBookRepository>(); 
          //  _bookService = new BookService(_unitofwork.Object, _bookRepository.Object, _mapMock);
        }

        [Fact]
        public async Task ShouldCreateBooksSucesfully()
        {
            //Arrange
            BookDTO bookDTO = GetBook();
            Book dbbook = GetBookDB();
            Book emptyBook = new Book();
            _bookRepository.Setup(x => x.Add(It.IsAny<Book>())).Returns(dbbook);
            //Act
           // var result = _bookService.Save(bookDTO);
            //Assert
            Assert.IsNotNull(null);

        }

        private BookDTO GetBook()
        {
            return new BookDTO
            {
                Name = "Test",
                Author = "Test",
                Department = "Test",
            };
        }
        private Book GetBookDB()
        {
            return new Book
            {
                Id = 1,
                Name = "Test",
                Author = "Test",
                Department = "Test",
            };
        }
    }
}
