using CFP.DataAccess.Entities;

namespace CFP.Application.DTOs
{
    public class CallForPaperResponse
    {
        public Guid UserId { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Plan { get; set; }
        public Status Status { get; set; }
        public DateTime? SubmitDate { get; set; }
    }
}
