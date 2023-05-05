using Mandiri_API.Data;
using Mandiri_API.Models;
using Mandiri_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mandiri_API.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public Task<List<ProjectUsers>> GetByUsersIdAsync(long userId)
        {
            //var data = _db.Project.Where(w => _db.ProjectUsers.Where(w => w.UsersId == userId).Select(s => s.ProjectId).Contains(w.Id)).ToListAsync();
            var data = _db.ProjectUsers.Where(w => w.UsersId == userId).ToListAsync();
            return data;
        }

        public async Task<Project> UpdateAsync(Project entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Project.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
