using System.ComponentModel.DataAnnotations;

namespace Mandiri_API.Models.Dto
{
    public class UsersDTO
    {
        public long Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Address { get; set; }
        
    }
}
