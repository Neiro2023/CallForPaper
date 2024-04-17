using System.ComponentModel.DataAnnotations;

namespace CFP.DataAccess.Entities
{
    public class CallForPaper
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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

        public Status Status { get; set; } = Status.Draft;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public DateTime? SubmitDate { get; set; }

        public void Set(CallForPaper callForPaper)
        {
            UserId = callForPaper.UserId;
            ActivityType = callForPaper.ActivityType;
            Name = callForPaper.Name;
            Discription = callForPaper.Discription;
            Plan = callForPaper.Plan;
            UpdateDate = DateTime.UtcNow;
        }

        public void Submit()
        {
            Status = Status.Sended;
            SubmitDate = DateTime.UtcNow;
        }
    }
}
