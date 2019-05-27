using Library.Contract.BookDto;
using Library.Infrastructure;

namespace Library.Core.Services.Mappers
{
    internal static class BookMapper
    {
        public static BookDto MapDtoToBook(Book book)
        {
            /*-------*/
            return new BookDto()
            {
                Title = book.Title,
                AuthorName = book.AuthorName,
                AuthorSurname = book.AuthorSurname,
                PublishingHouse = book.PublishingHouse,
                NumberOfSites = book.NumberOfSites,
                YearOfPublication = book.YearOfPublication
                /*RENTiNFOS*/
            };
        }

        public static Book MapBookToDto(BookDto book)
        {
            return new Book()
            {
                Title = book.Title,
                AuthorName = book.AuthorName,
                AuthorSurname = book.AuthorSurname,
                PublishingHouse = book.PublishingHouse,
                NumberOfSites = book.NumberOfSites,
                YearOfPublication = book.YearOfPublication
                /*RENTINFOS*/
            };
        }
    }
}