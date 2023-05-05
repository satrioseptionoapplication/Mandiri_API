using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandiri_API.Models
{
    public class ProjectUsers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Project")]
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Users")]
        public long UsersId { get; set; }
        public Users Users { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
