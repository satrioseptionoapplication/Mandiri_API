using System.ComponentModel.DataAnnotations;

namespace Mandiri_API.Models.Dto
{
    public class ProjectUsersDTO
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long UsersId { get; set; }
    }
}
