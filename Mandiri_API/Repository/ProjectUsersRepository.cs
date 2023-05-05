using Mandiri_API.Data;
using Mandiri_API.Models;
using Mandiri_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mandiri_API.Repository
{
    public class ProjectUsersRepository : Repository<ProjectUsers>, IProjectUsersRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectUsersRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<ProjectUsers> UpdateAsync(ProjectUsers entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.ProjectUsers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
