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

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBook/{Id}")]
        public async Task<IActionResult> GetBookById(long id)
        {
            try
            {
                var book = await _bookService.GetById(id);
                return Ok(book);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Can't found book with id = {id}");
            }
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            await _bookService.Add(book);
            return Created("Created new book", book);
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            await _bookService.Update(book);
            return Ok(value: $"Updated book with id = {book.Id}");
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            await _bookService.Delete(id);
            return Ok(value: $"Book with id = {id} deleted");
        }
    }
}