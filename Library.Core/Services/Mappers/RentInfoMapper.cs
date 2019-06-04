using Library.Contract.BookDto;
using Library.Infrastructure.Model;


namespace Library.Core.Services.Mappers
{
    internal static class RentInfoMapper
    {
        public static RentInfoDto MapDtoToRentInfo(RentInfo rentInfo)
        {
            return new RentInfoDto()
            {
                DateFrom = rentInfo.DateFrom,
                DateTo = rentInfo.DateTo,
                RentedBook = rentInfo.RentedBook,
                BorrowingUser = rentInfo.BorrowingUser
            };
        }

        public static RentInfo MapRentInfoToDto(RentInfoDto rentInfo)
        {
            return new RentInfo()
            {
                DateFrom = rentInfo.DateFrom,
                DateTo = rentInfo.DateTo,
                RentedBook = rentInfo.RentedBook,
                BorrowingUser = rentInfo.BorrowingUser
            };
        }
    }
}