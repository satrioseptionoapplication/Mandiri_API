using Mandiri_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mandiri_API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectUsers> ProjectUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Position>(entity => {
                entity.HasIndex(e => e.UsersId).IsUnique();
            });
            modelBuilder.Entity<Skill>(entity => {
                entity.HasIndex(e => new { e.UsersId, e.SkillName }).IsUnique();
            });
            modelBuilder.Entity<ProjectUsers>(entity => {
                entity.HasIndex(e => new { e.ProjectId, e.UsersId }).IsUnique();
            });


            modelBuilder.Entity<LocalUser>().HasData(
                new LocalUser
                {
                    Id = 1,
                    UserName = "admin",
                    Name = "admin",
                    Password = "admin",
                    Role = "admin"
                });

            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                Id = 1,
                FullName = "Satrio",
                Address = "Bogor",
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<Position>().HasData(
            new Position
            {
                Id = 1,
                Name = "Manager",
                UsersId = 1,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<Skill>().HasData(
            new Skill
            {
                Id = 1,
                UsersId = 1,
                SkillName = "Net Core",
                UpdatedDate = DateTime.Now
            },
            new Skill
            {
                Id = 2,
                UsersId = 1,
                SkillName = "Sql Server",
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "Kalkulator",
                UpdatedDate = DateTime.Now
            },
            new Project
            {
                Id = 2,
                Name = "Zuma",
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<ProjectUsers>().HasData(
            new ProjectUsers
            {
                Id = 1,
                ProjectId = 1,
                UsersId = 1,
                UpdatedDate = DateTime.Now
            },
            new ProjectUsers
            {
                Id = 2,
                ProjectId = 2,
                UsersId = 1,
                UpdatedDate = DateTime.Now
            });
        }
    }
}
