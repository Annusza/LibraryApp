using System.Threading.Tasks;

namespace Library.Infrastructure.Logic

{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserSurmane(string userSurname);
    }
}