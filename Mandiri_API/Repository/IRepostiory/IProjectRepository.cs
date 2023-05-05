using Mandiri_API.Models;
using System.Linq.Expressions;

namespace Mandiri_API.Repository.IRepostiory
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<ProjectUsers>> GetByUsersIdAsync(long entity);
        Task<Project> UpdateAsync(Project entity);
    }
}
