using Library.Contract.BookDto;
using Library.Infrastructure.Model;


namespace Library.Core.Services.Mappers
{
    internal static class RentInfoMapper
    {
        public static RentInfoDto MapRentInfoToRentInfoDto(RentInfo rentInfo)
        
        {
            return new RentInfoDto()
            {
                DateFrom = rentInfo.DateFrom,
                DateTo = rentInfo.DateTo,
                
                //RentedBook = BookMapper.MapBookDtoToBook((BookDto) rentInfo.RentedBook);
                RentedBook =BookMapper.MapBookToBookDto(rentInfo.RentedBook),
               //BorrowingUser = rentInfo.BorrowingUser
               BorrowingUser = UserMapper.MapUserToUserDto(rentInfo.BorrowingUser),
               Id = rentInfo.Id
            };
        }

        public static RentInfo MapRentInfoDtoToRentInfo(RentInfoDto rentInfo)
        {
            return new RentInfo()
            {
                DateFrom = rentInfo.DateFrom,
                DateTo = rentInfo.DateTo,
                Id = rentInfo.Id
                /*
                RentedBook = rentInfo.RentedBook,
                BorrowingUser = rentInfo.BorrowingUser*/
            };
        }
        
        
    }
}