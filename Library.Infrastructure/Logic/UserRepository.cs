using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Logic

{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _libraryContext;

        public UserRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _libraryContext.User.ToListAsync();
            // users.ForEach(action: x => {_libraryContext.Entry(x).Reference(propertyExpression: y => y.RentInfos).LoadAsync();});
            return users;
        }


        public async Task<User> GetById(long id)
        {
            var user = await _libraryContext.User
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
          

            return user;
        }

        public async Task Add(User entity)
        {
            entity.DateOfCreation = DateTime.Now;
            
            entity.Id = null;
            await _libraryContext.User.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            var userToUpdate = await _libraryContext.User
                .Include(navigationPropertyPath: x => x.RentInfos)
                .SingleOrDefaultAsync(predicate: x => x.Id == entity.Id);

            if (userToUpdate != null)
            {
                userToUpdate.Name = entity.Name;
                userToUpdate.Surname = entity.Surname;
                userToUpdate.DateOfUpdate = DateTime.Now;
           

                await _libraryContext.SaveChangesAsync();
            }
        }

       

        public async Task Delete(long id)
        {
            var userToDelete = await _libraryContext.User.SingleOrDefaultAsync(predicate: user => user.Id == id);
            if (userToDelete != null)
            {
                _libraryContext.User.Remove(userToDelete);
                await _libraryContext.SaveChangesAsync();
            }
        }


        public async Task<User> GetByUserSurmane(string userSurname)
        {
            var user = await _libraryContext.User
                .Where(x => x.Surname == userSurname)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(user).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
            return user;
        }
        
        public async Task<User> GetUserWithMaxBooksRead()
        {
            var rentInfos = _libraryContext.RentInfo;
            
            foreach(var line in rentInfos.GroupBy(info => info.BorrowingUser.Id)
                .OrderByDescending(group => group.Count())
                .Select(group => Tuple.Create(  
                    group.Key, 
                    group.Count())).Take(1)
            )

            {
                var topUserId = line.Item1.GetValueOrDefault();
                var count = line.Item2;

                return await GetById(topUserId);
            }

            return null;
        }
    }
    
    
}