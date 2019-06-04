using System.Threading.Tasks;

namespace Library.Infrastructure.Logic

{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetByUserSurmane(string userSurname);
    }
}