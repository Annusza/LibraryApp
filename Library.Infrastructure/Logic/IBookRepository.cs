

using System.Threading.Tasks;

namespace Library.Infrastructure.Logic
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetByTitle(string title);
        Task<Book> GetByAuthorName(string name);
        Task<Book> GetByAuthorSurmane(string surname);
        Task<Book> GetByYearOfPublication(int yearOfPublication);
        Task<Book> GetByPublishingHouse(string publishingHouse);
    }
}

