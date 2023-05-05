using System.ComponentModel.DataAnnotations;

namespace Mandiri_API.Models.Dto
{
    public class SkillDTO
    {
        public long Id { get; set; }
        public long UsersId { get; set; }
        [Required]
        [MaxLength(30)]
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }
    }
}
