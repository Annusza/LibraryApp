using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Model

{
    public class RentInfo : Entity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Book RentedBook { get; set; }
        public User BorrowingUser { get; set; }
    }
}