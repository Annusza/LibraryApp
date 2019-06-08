using System;
using System.Collections.Generic;
using Library.Infrastructure;

namespace Library.Contract.BookDto
{
    public class BookDto : BaseDto
    {
        
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Title { get; set; }
        public int? YearOfPublication { get; set; }
        public int? NumberOfSites { get; set; }
        public string PublishingHouse { get; set; }
        
        
       
        
        
        /*
         * 
     
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        
        public IEnumerable<Book> RentedBook { get; set; }
        public IEnumerable<User> BorrowingUser { get; set; }
        
         RentInfos */

    }
}