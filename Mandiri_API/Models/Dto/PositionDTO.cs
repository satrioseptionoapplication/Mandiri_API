using System.ComponentModel.DataAnnotations;

namespace Mandiri_API.Models.Dto
{
    public class PositionDTO
    {
        public long Id { get; set; }
        public long UsersId { get; set; }
        public string Name { get; set; }
    }
}
