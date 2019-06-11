using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services.Mappers;
using Library.Infrastructure;
using Library.Infrastructure.Logic;

namespace Library.Core.Services

{
    public class UserService : IUserService
    
    
    {
        private readonly IUserRepository _iUserRepository;

        public UserService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _iUserRepository.GetAll();
            return users
                .Select(UserMapper.MapUserToUserDto)
                .ToList();
        }

        public async Task<UserDto> GetById(long id)
        {
            var user = await _iUserRepository.GetById(id);
            return UserMapper.MapUserToUserDto(user);
        }

        public async Task Add(UserDto dto)
        {
            await _iUserRepository.Add(UserMapper.MapUserDtoToUser(dto));
        }

        public async Task Update(UserDto dto)
        {
            await _iUserRepository.Update(UserMapper.MapUserDtoToUser(dto));
        }

        public async Task Delete(long id)
        {
            await _iUserRepository.Delete(id);
        }
        
        public async Task<UserDto> GetUserWithMaxBooksRead()
        {
            var user = await _iUserRepository.GetUserWithMaxBooksRead();
            return UserMapper.MapUserToUserDto(user);
        }
    }
}