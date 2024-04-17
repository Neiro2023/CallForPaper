using CFP.Application.DTOs;
using CFP.DataAccess.Entities;

namespace CFP.Application.Mappers
{
    public class CallForPaperMapper
    {
        public CallForPaper MapFrom(CallForPaperRequest request)
        {
            return new()
            {
                UserId = request.UserId,
                ActivityType = request.ActivityType,
                Name = request.Name,
                Discription = request.Discription,
                Plan = request.Plan
            };
        }

        public CallForPaperResponse MapFrom(CallForPaper callForPaper)
        {
            return new()
            {
                UserId = callForPaper.UserId,
                ActivityType = callForPaper.ActivityType,
                Name = callForPaper.Name,
                Discription = callForPaper.Discription,
                Plan = callForPaper.Plan,
                Status = callForPaper.Status,
                SubmitDate = callForPaper.SubmitDate
            };
        }
    }
}
