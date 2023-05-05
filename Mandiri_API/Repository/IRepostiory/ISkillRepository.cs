using Mandiri_API.Models;
using System.Linq.Expressions;

namespace Mandiri_API.Repository.IRepostiory
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<List<Skill>> GetByUsersIdAsync(long entity);
        Task<Skill> UpdateAsync(Skill entity);
    }
}
