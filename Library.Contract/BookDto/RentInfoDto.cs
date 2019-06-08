using System;
using System.Collections.Generic;
using Library.Infrastructure;


namespace Library.Contract.BookDto
{

   /* public class RentInfoDto : BaseDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        
        public BookDto RentedBook { get; set; }
        public UserDto BorrowingUser { get; set; }
    }*/



    public class RentInfoDto : BaseDto
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        
        public long? BorrowingUserId { get; set; }
        public long? RentedBookId { get; set; }
        
        public string BorrowingUserString { get; set; }
        public string RentedBookString { get; set; }
        
     /* 707
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Title { get; set; }
        public int? YearOfPublication { get; set; }
        public int? NumberOfSites { get; set; }
        public string PublishingHouse { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }*/

      //  public BookDto RentedBook { get; set; }
      //  public UserDto BorrowingUser { get; set; }
    }
}