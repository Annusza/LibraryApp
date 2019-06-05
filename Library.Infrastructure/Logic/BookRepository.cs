using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Logic

{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public async Task<IEnumerable<Book>> GetAll()
        {
         
            var books = await _libraryContext.Book.ToListAsync();
            books.ForEach(action: x => { _libraryContext.Entry(x).Reference(propertyExpression: y => y.RentInfos).LoadAsync();});
            return books;
        }

        public async Task<Book> GetById(long id)
        {
          
            var book = await _libraryContext.Book
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            try
            {
                await _libraryContext.Entry(book).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            }
            catch (ArgumentException e)
            {
                return null;
            }
            
            return book;
        }

        public async Task Add(Book book)
        {
            book.DateOfCreation = DateTime.Now;
            await _libraryContext.Book
              
                .Include(navigationPropertyPath: x=>x.RentInfos)
            
                .FirstAsync();
            await _libraryContext.Book.AddAsync(book);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task Update(Book entity)
        {
            var bookToUpdate = await _libraryContext.Book
                    
               // CZY TYLKO OBIEKTOWE CZY WSZYSTKIE POLA???
                .Include(navigationPropertyPath:x=>x.RentInfos)
                .SingleOrDefaultAsync(predicate: x => x.Id == entity.Id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = entity.Title;
                bookToUpdate.AuthorName = entity.AuthorName;
                bookToUpdate.AuthorSurname = entity.AuthorSurname;
                bookToUpdate.PublishingHouse = entity.PublishingHouse;
                bookToUpdate.YearOfPublication = entity.YearOfPublication;
                bookToUpdate.NumberOfSites = entity.NumberOfSites;
                bookToUpdate.DateOfUpdate = DateTime.Now;
                bookToUpdate.RentInfos = entity.RentInfos;

                if (entity.RentInfos != null && bookToUpdate.RentInfos != null)
                {
                    var rentInfosToUpdate = bookToUpdate.RentInfos.ToList();
                    foreach (var rentInfo in rentInfosToUpdate)
                    {
                        foreach (var entityRentInfo in entity.RentInfos)
                        {
                            if (rentInfo.Id == entityRentInfo.Id)
                            {
                                _libraryContext.Entry(rentInfosToUpdate).CurrentValues.SetValues(entity.RentInfos);
                            }
                        }
                       
                    }
                  
                }

                await _libraryContext.SaveChangesAsync();
            }
            
  
        }

        public async Task Delete(long id)
        {
            var bookToDelete = await _libraryContext.Book.SingleOrDefaultAsync(predicate: book => book.Id == id);
            if (bookToDelete != null)
            {
                _libraryContext.Book.Remove(bookToDelete);
                await _libraryContext.SaveChangesAsync();
            }
        }
/*my*/

        public async Task<Book> GetByTitle(string title)
        {
            var book = await _libraryContext.Book
                .Where(x => x.Title == title)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(book).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            return book;
        }

        public async Task<Book> GetByAuthorName(string name)
        {
            var book = await _libraryContext.Book
                .Where(x => x.AuthorName==name)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(book).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            return book;
        }

        public async Task<Book> GetByAuthorSurmane(string surname)
        {
            var book = await _libraryContext.Book
                .Where(x => x.AuthorSurname==surname)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(book).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            return book;
        }

        public async Task<Book> GetByYearOfPublication(int yearOfPublication)
        {
            var book = await _libraryContext.Book
                .Where(x => x.YearOfPublication==yearOfPublication)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(book).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            return book;
        }

        public async Task<Book> GetByPublishingHouse(string publishingHouse)
        {
            var book = await _libraryContext.Book
                .Where(x => x.PublishingHouse==publishingHouse)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(book).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            return book;
        }
    }
}

