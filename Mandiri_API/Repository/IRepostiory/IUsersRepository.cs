using Mandiri_API.Models;
using System.Linq.Expressions;

namespace Mandiri_API.Repository.IRepostiory
{
    public interface IUsersRepository : IRepository<Users>
    {
        Task<UsersDetail> CreateUsersDetailAsync(UsersDetail entity);
        Task<UsersDetail> UpdateUsersDetail(UsersDetail entity);
        Task<Users> UpdateAsync(Users entity);
    }
}
