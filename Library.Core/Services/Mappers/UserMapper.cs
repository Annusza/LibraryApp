using Library.Contract.BookDto;
using Library.Infrastructure;

namespace Library.Core.Services.Mappers

{
    internal static class UserMapper
    {
        public static UserDto MapUserToUserDto(User user)
        {
            return new UserDto()
            {
                Name = user.Name,
                Surname = user.Surname
            };
        }

        public static User MapUserDtoToUser(UserDto user)
        {
            return new User()
            {
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}