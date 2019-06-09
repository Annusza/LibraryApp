using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Logic
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetByTitle(string title);
        Task<IEnumerable<Book>> GetByAuthorSurname(string authorSurname);
        
    }
}

