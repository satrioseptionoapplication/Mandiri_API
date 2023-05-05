using Mandiri_API.Models;
using System.Linq.Expressions;

namespace Mandiri_API.Repository.IRepostiory
{
    public interface IProjectUsersRepository : IRepository<ProjectUsers>
    {

        Task<ProjectUsers> UpdateAsync(ProjectUsers entity);
    }
}
