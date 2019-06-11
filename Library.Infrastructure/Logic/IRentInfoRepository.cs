using System;
using System.Threading.Tasks;
using Library.Infrastructure.Model;

namespace Library.Infrastructure.Logic

{
    public interface IRentInfoRepository : IRepository<RentInfo>
    {
        Task<RentInfo> GetByDateFrom(DateTime dateFrom);
        Task<RentInfo> GetByDateTo(DateTime dateTo);
    }
}