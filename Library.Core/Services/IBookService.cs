using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Contract.BookDto;

namespace Library.Core.Services

{
    public interface IBookService : IService<BookDto>
    {
        Task<IEnumerable<BookDto>> GetByTitle(string title);
        Task<IEnumerable<BookDto>> GetByAuthorSurname(string dtoAuthorSurname);
    }
}