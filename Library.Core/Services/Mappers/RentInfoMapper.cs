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
                DateFrom = rentInfo.DateFrom,
                DateTo = rentInfo.DateTo,
                Id = rentInfo.Id,
                BorrowingUserId = rentInfo.BorrowingUser?.Id,
                RentedBookId = rentInfo.RentedBook?.Id,
                BorrowingUserString = rentInfo.BorrowingUser?.Surname,
                RentedBookString = rentInfo.RentedBook?.Title
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