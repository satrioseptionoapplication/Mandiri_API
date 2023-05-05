using Mandiri_API.Data;
using Mandiri_API.Models;
using Mandiri_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mandiri_API.Repository
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        private readonly ApplicationDbContext _db;
        public SkillRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public Task<List<Skill>> GetByUsersIdAsync(long userId)
        {
            var data = _db.Skill.Where(w => w.UsersId == userId).ToListAsync();
            return data;
        }

        public async Task<Skill> UpdateAsync(Skill entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Skill.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
