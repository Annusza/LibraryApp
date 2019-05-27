using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task Add(TEntity book);
        Task Update(TEntity entity);
        Task Delete(long id);
    }
}