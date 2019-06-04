using System;
using System.Collections.Generic;
using Library.Infrastructure;


namespace Library.Contract.BookDto
{
    public class RentInfoDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        
        public IEnumerable<Book> RentedBook { get; set; }
        public IEnumerable<User> BorrowingUser { get; set; }
    }
}