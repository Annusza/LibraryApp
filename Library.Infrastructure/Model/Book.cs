using System.Collections.Generic;
using Library.Infrastructure.Model;

namespace Library.Infrastructure
{
    public class Book : Entity
    {
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public int NumberOfSites { get; set; }
        public string PublishingHouse { get; set; }

        public IEnumerable<RentInfo> RentInfos { get; set; }
    }
}