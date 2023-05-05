using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandiri_API.Models
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Users")]
        public long UsersId { get; set; }
        public Users Users { get; set; }
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
