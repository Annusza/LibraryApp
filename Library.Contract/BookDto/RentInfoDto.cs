using System;
using System.Collections.Generic;
using Library.Infrastructure;


namespace Library.Contract.BookDto
{
    public class RentInfoDto : BaseDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        
        public BookDto RentedBook { get; set; }
        public UserDto BorrowingUser { get; set; }
    }
}