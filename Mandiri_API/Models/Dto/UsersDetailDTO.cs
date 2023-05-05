using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandiri_API.Models.Dto
{
    public class UsersDetailDTO
    {
        public UsersDTO Users { get; set; }
        public PositionDTO Position { get; set; }
        public List<SkillDTO> Skill { get; set; }
        public List<ProjectUsersDTO> ProjectUsers { get; set; }
    }
}
