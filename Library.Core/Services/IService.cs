using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task Add(TEntity dto);
        Task Update(TEntity dto);
        Task Delete(long id);
    }
}