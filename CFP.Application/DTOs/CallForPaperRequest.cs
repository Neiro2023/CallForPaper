using CFP.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace CFP.Application.DTOs
{
    public class CallForPaperRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public ActivityType ActivityType { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Discription { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Plan { get; set; }
    }
}
