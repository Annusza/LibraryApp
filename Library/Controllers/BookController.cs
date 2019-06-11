using System;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _iBookService;


        public BookController(IBookService iBookService)
        {
            _iBookService = iBookService;
        }


        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBookById(long id)
        {
            try
            {
                var book = await _iBookService.GetById(id);
                return Ok(book);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Not found book with id = {id}");
            }
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _iBookService.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            await _iBookService.Add(book);
            return Created("Created new book", book);
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            await _iBookService.Update(book);
            return Ok(value: $"Updated book with id = {book.Id}");
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            await _iBookService.Delete(id);
            return Ok(value: $"Book with id = {id} deleted");
        }

        [HttpGet("GetByTitle/{title}")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            try
            {
                var book = await _iBookService.GetByTitle(title);
                return Ok(book);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Not found book with title = {title}");
            }
        }

        [HttpGet("GetByAuthorSurname/{authorSurname}")]
        public async Task<IActionResult> GetBookByAuthorSurname(string authorSurname)
        {
            try
            {
                var book = await _iBookService.GetByAuthorSurname(authorSurname);
                return Ok(book);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Not found book with title = {authorSurname}");
            }
        }
    }
}