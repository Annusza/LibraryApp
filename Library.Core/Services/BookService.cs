using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services.Mappers;
using Library.Infrastructure.Logic;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _iBookRepository;

        public BookService(IBookRepository iBookRepository)
        {

            _iBookRepository = iBookRepository;
        }
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _iBookRepository.GetAll();
            return books
                .Select(BookMapper.MapBookToBookDto)
                .ToList();
        }

        public async Task<BookDto> GetById(long id)
        {
            var book = await _iBookRepository.GetById(id);
            return BookMapper.MapBookToBookDto(book);
        }

        public async Task Add(BookDto dto)
        {
            await _iBookRepository.Add(BookMapper.MapBookDtoToBook(dto));
        }

        public async Task Update(BookDto dto)
        {
            await _iBookRepository.Update(BookMapper.MapBookDtoToBook(dto));
        }

        public async Task Delete(long id)
        {
            await _iBookRepository.Delete(id);
        }
    }
}