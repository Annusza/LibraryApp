using System;

namespace Library.Contract.BookDto
{
    public class BookDto
    {
        // czy tu też obiekty?? RentInfo?
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public int NumberOfSites { get; set; }
        public string PublishingHouse { get; set; }
        
        
        /* RentInfos */

    }
}