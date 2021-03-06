using Library.Contract.BookDto;
using Library.Infrastructure;

namespace Library.Core.Services.Mappers

{
    internal static class BookMapper
    {
        public static BookDto MapBookToBookDto(Book book)
        {
            return new BookDto()
            {
                Title = book.Title,
                AuthorName = book.AuthorName,
                AuthorSurname = book.AuthorSurname,
                PublishingHouse = book.PublishingHouse,
                NumberOfSites = book.NumberOfSites,
                YearOfPublication = book.YearOfPublication,
                Id = book.Id
            };
        }

        public static Book MapBookDtoToBook(BookDto book)
            //
        {
            return new Book()
            {
                Title = book.Title,
                AuthorName = book.AuthorName,
                AuthorSurname = book.AuthorSurname,
                PublishingHouse = book.PublishingHouse,
                NumberOfSites = book.NumberOfSites.GetValueOrDefault(),
                YearOfPublication = book.YearOfPublication.GetValueOrDefault(),
                Id = book.Id.GetValueOrDefault()
            };
        }
    }
}