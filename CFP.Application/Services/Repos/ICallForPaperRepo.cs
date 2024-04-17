using CFP.DataAccess.Entities;

namespace CFP.Application.Services.Repos
{
    public interface ICallForPaperRepo
    {
        Task<Guid> Create(CallForPaper callForPaper);
        Task Update(CallForPaper callForPaper);
        Task Remove(CallForPaper itemToRemove);
        Task<List<CallForPaper>> Get();
        Task<CallForPaper> GetById(Guid id);
        Task<CallForPaper> GetByUserId(Guid id);
    }
}
