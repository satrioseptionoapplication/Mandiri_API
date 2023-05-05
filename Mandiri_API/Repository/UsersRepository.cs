using Mandiri_API.Data;
using Mandiri_API.Models;
using Mandiri_API.Models.Dto;
using Mandiri_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mandiri_API.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly ApplicationDbContext _db;
        public UsersRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<UsersDetail> CreateUsersDetailAsync(UsersDetail entity)
        {
            // USERS
            _db.Users.AddAsync(entity.Users);
            await _db.SaveChangesAsync();

            // POSITION
            entity.Position.UsersId = entity.Users.Id;
            _db.Position.AddAsync(entity.Position);

            // SKILL
            foreach (Skill skill in entity.Skill)
            {
                skill.UsersId = entity.Users.Id;
                _db.Skill.AddAsync(skill);
            }

            // PROJECT
            foreach (ProjectUsers projectUsers in entity.ProjectUsers)
            {
                projectUsers.UsersId = entity.Users.Id;
                _db.ProjectUsers.AddAsync(projectUsers);
            }

            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<UsersDetail> UpdateUsersDetail(UsersDetail entity)
        {
            // USERS
            _db.Users.Update(entity.Users);

            // POSITION
            _db.Position.Update(entity.Position);

            // SKILL
            foreach (Skill skill in entity.Skill)
            {
                if (skill.Id == 0)
                {
                    skill.UsersId = entity.Users.Id;
                    _db.Skill.Add(skill);
                }
                else
                {
                    _db.Skill.Update(skill);
                }

            }

            //// PROJECT
            foreach (ProjectUsers projectUsers in entity.ProjectUsers)
            {
                if (projectUsers.Id == 0)
                {
                    projectUsers.UsersId = entity.Users.Id;
                    _db.ProjectUsers.Add(projectUsers);
                }
                else
                {
                    _db.ProjectUsers.Update(projectUsers);
                }

            }

            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Users> UpdateAsync(Users entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        
    }
}
