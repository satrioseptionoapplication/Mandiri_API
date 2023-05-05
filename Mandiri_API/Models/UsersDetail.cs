using Mandiri_API.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandiri_API.Models
{
    public class UsersDetail
    {
        public Users Users { get; set; }
        public Position Position { get; set; }
        public List<Skill> Skill { get; set; }
        public List<ProjectUsers> ProjectUsers { get; set; }
    }
}
