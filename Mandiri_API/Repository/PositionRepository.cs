using Mandiri_API.Data;
using Mandiri_API.Models;
using Mandiri_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mandiri_API.Repository
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _db;
        public PositionRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Position> UpdateAsync(Position entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Position.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
