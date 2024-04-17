using CFP.Application.DTOs;
using CFP.DataAccess.Entities;

namespace CFP.Application.Services
{
    public interface ICallForPaperService
    {
        Task<Guid> Create(CallForPaperRequest request);
        Task Update(Guid id, CallForPaperRequest request);
        Task Remove(Guid id);
        Task SendForReview(Guid id);
        Task<List<CallForPaperResponse>> GetSended(DateTime date);
        Task<List<CallForPaperResponse>> GetDrafts(DateTime date);
        Task<CallForPaperResponse> GetUserDraft(Guid userId);
        Task<CallForPaperResponse> GetById(Guid id);
        List<ActivityType> GetActivities();
    }
}
