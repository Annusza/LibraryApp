using Library.Contract.BookDto;
using Library.Infrastructure;
using Library.Infrastructure.Model;


namespace Library.Core.Services.Mappers
{
    internal static class RentInfoMapper
    {
        public static RentInfoDto MapRentInfoToRentInfoDto(RentInfo rentInfo)

        {
            return new RentInfoDto()
            {
                //RentedBook = BookMapper.MapBookDtoToBook((BookDto) rentInfo.RentedBook);
                /*  RentedBook =BookMapper.MapBookToBookDto(rentInfo.RentedBook),*/
                //BorrowingUser = rentInfo.BorrowingUser
                /* BorrowingUser = UserMapper.MapUserToUserDto(rentInfo.BorrowingUser),*/


                DateFrom = rentInfo.DateFrom,
                DateTo = rentInfo.DateTo,
                Id = rentInfo.Id,
                BorrowingUserId = rentInfo.BorrowingUser?.Id,
                RentedBookId = rentInfo.RentedBook?.Id,
                BorrowingUserString = rentInfo.BorrowingUser?.Surname,
                RentedBookString = rentInfo.RentedBook?.Title


                /* 707
                 * Name = rentInfo.BorrowingUser.Name,
                 
                 Surname = rentInfo.BorrowingUser.Surname,
 
 
                 AuthorName = rentInfo.RentedBook.AuthorName,
                 AuthorSurname = rentInfo.RentedBook.AuthorSurname,
                 NumberOfSites = rentInfo.RentedBook?.NumberOfSites,
                 PublishingHouse = rentInfo.RentedBook.PublishingHouse,
                 Title = rentInfo.RentedBook.Title,
                 YearOfPublication = rentInfo.RentedBook?.YearOfPublication
                 */
            };
        }

        public static RentInfo MapRentInfoDtoToRentInfo(RentInfoDto rentInfo)
        {
            return new RentInfo()
            {
                DateFrom = rentInfo.DateFrom.GetValueOrDefault(),
                DateTo = rentInfo.DateTo.GetValueOrDefault(),
                Id = rentInfo.Id.GetValueOrDefault()
            };
        }
    }
}