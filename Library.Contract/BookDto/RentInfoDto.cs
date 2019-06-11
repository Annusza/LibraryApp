using System;
using System.Collections.Generic;
using Library.Infrastructure;


namespace Library.Contract.BookDto
{
    public class RentInfoDto : BaseDto
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public long? BorrowingUserId { get; set; }
        public long? RentedBookId { get; set; }

        public string BorrowingUserString { get; set; }
        public string RentedBookString { get; set; }
    }
}