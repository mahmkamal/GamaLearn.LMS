using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using GamaLearn.LMS.Services.Interfaces;
using GamaLearn.LMS.Models.DTO;
using GamaLearn.LMS.Models.Entites;
using Microsoft.Exchange.WebServices.Data;

namespace APIS.Controllers
{
    [EnableCors("TaskPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _AutoMapper;
        private readonly ILogger<BookDTO> _logger;

        public BooksController(IBookService bookService, IMapper AutoMapper, ILogger<BookDTO> logger)
        {
            _bookService = bookService;
            _AutoMapper = AutoMapper;
            _logger = logger;
        }
        [HttpPost]
        public BookDTO Save(BookDTO posted)
        {
            try
            {
                _logger.LogInformation($"Starting to execute method: {nameof(this.Save)}");

                var _Book = _bookService.Save(_AutoMapper.Map<BookDTO>(posted));
                // _Book.Password = null; in case of sending model with password , we have to make it nullable
                _logger.LogInformation($"Response received from service method: {nameof(_bookService.Save)}");

                return _AutoMapper.Map<BookDTO>(_Book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Encountered an error processing: {nameof(this.Save)}");

                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation($"Starting to execute method: {nameof(this.GetAll)}");
                var data = await _bookService.GetAll();
                _logger.LogInformation($"Response received from service method: {nameof(_bookService.GetAll)}");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Encountered an error processing: {nameof(this.GetAll)} exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public BookDTO GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Starting to execute method: {nameof(this.GetById)}");
                var _Book = _bookService.Get(id);
                _logger.LogInformation($"Response received from service method: {nameof(_bookService.Get)}");

                //   _Book.Password = null;in case of sending model with password , we have
                return _AutoMapper.Map<BookDTO>(_Book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Encountered an error processing: {nameof(this.GetById)} exception: {ex.Message}");
                throw new Exception(StatusCode(StatusCodes.Status500InternalServerError, ex.Message).ToString());
            }

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Starting to execute method: {nameof(this.Delete)}");
                _bookService.Delete(id);
                _logger.LogInformation($"Response received from service method: {nameof(_bookService.Delete)}");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Encountered an error processing: {nameof(this.Delete)} exception: {ex.Message}");
                throw new Exception(StatusCode(StatusCodes.Status500InternalServerError, ex.Message).ToString());
            }
        }

        #region loginOption below for in in case of has a login option 
        public class logindata
        {
            public BookDTO? Book { get; set; }
            public string? Token { get; set; }
            public bool isSucceeded { get; set; }
            public bool isBlocked { get; set; }
            public bool lastLogin { get; set; }
        }
        #endregion
    }
}
