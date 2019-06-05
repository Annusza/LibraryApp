using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using Library.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Logic

{
    public class RentInfoRepository : IRentInfoRepository
    {

        private readonly LibraryContext _libraryContext;

        public RentInfoRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public async Task<IEnumerable<RentInfo>> GetAll()
        {
            var rentInfos = await _libraryContext.RentInfo.ToListAsync();
            rentInfos.ForEach(action: x =>
            {
                _libraryContext.Entry(x).Reference(propertyExpression: y => y.RentedBook).LoadAsync();});
            
            rentInfos.ForEach(action: x =>
            {
                _libraryContext.Entry(x).Reference(propertyExpression: y => y.BorrowingUser).LoadAsync();});
            
            return rentInfos;
        }

        public async Task<RentInfo> GetById(long id)
        {
            var rentInfo = await _libraryContext.RentInfo
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(rentInfo).Reference(propertyExpression: x => x.RentedBook).LoadAsync();
            await _libraryContext.Entry(rentInfo).Reference(propertyExpression: x => x.BorrowingUser).LoadAsync();
            return rentInfo;
        }

        public async Task Add(RentInfo entity)
        {
            entity.DateOfCreation = DateTime.Now;
            await _libraryContext.RentInfo
                .Include(navigationPropertyPath: x=>x.RentedBook)
                .Include(navigationPropertyPath:x=>x.BorrowingUser)
                .FirstAsync();
            await _libraryContext.RentInfo.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task Update(RentInfo entity)
        {
            var rentInfoToUpdate = await _libraryContext.RentInfo
                .Include(navigationPropertyPath:x=>x.RentedBook)
                .Include(navigationPropertyPath:x=>x.BorrowingUser)
                .SingleOrDefaultAsync(predicate: x => x.Id == entity.Id);

            if (rentInfoToUpdate != null)
            {
                rentInfoToUpdate.DateFrom = entity.DateFrom;
                rentInfoToUpdate.DateTo = entity.DateTo;
                rentInfoToUpdate.DateOfUpdate = DateTime.Now;
                

           

                await _libraryContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long id)
        {
            var rentInfoToDelete = await _libraryContext.RentInfo.SingleOrDefaultAsync(predicate: rentInfo => rentInfo.Id == id);
            if (rentInfoToDelete != null)
            {
                _libraryContext.RentInfo.Remove(rentInfoToDelete);
                await _libraryContext.SaveChangesAsync();
            }
        }

        public async Task<RentInfo> GetByDateFrom(DateTime dateFrom)
        {
            var rentInfo = await _libraryContext.RentInfo
                .Where(x => x.DateFrom==dateFrom)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(rentInfo).Reference(propertyExpression: x => x.RentedBook).LoadAsync();
            await _libraryContext.Entry(rentInfo).Reference(propertyExpression: x => x.BorrowingUser).LoadAsync();
            return rentInfo;
        }

        public async Task<RentInfo> GetByDateTo(DateTime dateTo)
        {
            var rentInfo = await _libraryContext.RentInfo
                .Where(x => x.DateTo==dateTo)
                .SingleOrDefaultAsync();
            await _libraryContext.Entry(rentInfo).Reference(propertyExpression: x => x.RentedBook).LoadAsync();
            await _libraryContext.Entry(rentInfo).Reference(propertyExpression: x => x.BorrowingUser).LoadAsync();
            return rentInfo;
        }
    }
}