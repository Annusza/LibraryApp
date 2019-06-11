using System.Threading.Tasks;
using Library.Contract.BookDto;

namespace Library.Core.Services.Mappers

{
    public interface IUserService : IService<UserDto>
    {
        Task<UserDto> GetUserWithMaxBooksRead();
    }
}