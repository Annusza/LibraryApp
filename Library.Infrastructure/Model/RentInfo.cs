using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Model

{
    public class RentInfo : Entity
    {
        
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        
        public IEnumerable<Book> RentedBook { get; set; }
        public IEnumerable<User> BorrowingUser { get; set; }
    }
}