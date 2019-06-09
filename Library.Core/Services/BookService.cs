using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services.Mappers;
using Library.Infrastructure;
using Library.Infrastructure.Logic;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {

            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _bookRepository.GetAll();
            return books
                .Select(BookMapper.MapBookToBookDto)
                .ToList();
        }
        

        public async Task<BookDto> GetById(long id)
        {
            var book = await _bookRepository.GetById(id);
            return BookMapper.MapBookToBookDto(book);
        }

        public async Task Add(BookDto dto)
        {
            await _bookRepository.Add(BookMapper.MapBookDtoToBook(dto));
        }

        public async Task Update(BookDto dto)
        {
            await _bookRepository.Update(BookMapper.MapBookDtoToBook(dto));
        }

        public async Task Delete(long id)
        {
            await _bookRepository.Delete(id);
        }

// my

        public async Task<IEnumerable<BookDto>> GetByTitle(string dto)
        {
            var books = await _bookRepository.GetByTitle(dto);
            return books.Select(BookMapper.MapBookToBookDto).ToList();
            
         
        }

        public async Task<IEnumerable<BookDto>> GetByAuthorSurname(string dtoAuthorSurname)
        {
            var books = await _bookRepository.GetByAuthorSurname(dtoAuthorSurname);
            return books.Select(BookMapper.MapBookToBookDto).ToList();
        }
    }
}