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
            /* try
              {
                  await _libraryContext.Entry(user).Reference(propertyExpression: x => x.RentInfos).LoadAsync();
              }
              catch (ArgumentException e)
              {
                  return null;
              }*/

            return user;
        }

        public async Task Add(User entity)
        {
            entity.DateOfCreation = DateTime.Now;
            /* await _libraryContext.User
                 .Include(navigationPropertyPath: x=>x.RentInfos)
                 .FirstAsync();*/
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
                //707
                //userToUpdate.RentInfos = entity.RentInfos;

                /*if (entity.RentInfos != null && userToUpdate.RentInfos != null)
                {
                    var rentInfosToUpdate = userToUpdate.RentInfos.ToList();
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
                  
                }*/

                await _libraryContext.SaveChangesAsync();
            }
        }

       // public async Task<>

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
    }
    
    
}