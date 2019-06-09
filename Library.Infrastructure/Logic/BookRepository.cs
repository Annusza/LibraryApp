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
            return books;
        }

        public async Task<Book> GetById(long id)
        {
          
            var book = await _libraryContext.Book
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            
            return book;
        }

        public async Task Add(Book book)
        {
            book.DateOfCreation = DateTime.Now;
           book.Id = null;
            await _libraryContext.Book.AddAsync(book);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task Update(Book entity)
        {
            var bookToUpdate = await _libraryContext.Book
                
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


// searching by title

        public async Task<IEnumerable<Book>> GetByTitle(string title)
        {
            var books = await _libraryContext.Book
                .Where(x => x.Title == title)
                .ToListAsync();
            return books;
        }

      
// searching by author's surname
  
        public async Task<IEnumerable<Book>> GetByAuthorSurname(string authorSurname)
        {
            var books = await _libraryContext.Book
                .Where(x => x.AuthorSurname==authorSurname)
                .ToListAsync();
            return books;
        }
    }
}

