using Mandiri_API.Models;
using System.Linq.Expressions;

namespace Mandiri_API.Repository.IRepostiory
{
    public interface IPositionRepository : IRepository<Position>
    {

        Task<Position> UpdateAsync(Position entity);
    }
}
