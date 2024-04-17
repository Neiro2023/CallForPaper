using CFP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Application.Services.Repos
{
    public class CallForPaperRepo : ICallForPaperRepo
    {
        private readonly CallForPaperContext _context;

        public CallForPaperRepo(CallForPaperContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CallForPaper callForPaper)
        {
            await _context.CallForPapers.AddAsync(callForPaper);
            await _context.SaveChangesAsync();
            return callForPaper.Id;
        }

        public async Task<List<CallForPaper>> Get()
        {
            return await _context.CallForPapers.AsNoTracking().ToListAsync();
        }

        public async Task<CallForPaper> GetById(Guid id)
        {
            return await _context.CallForPapers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CallForPaper> GetByUserId(Guid id)
        {
            return await _context.CallForPapers.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task Remove(CallForPaper itemToRemove)
        {
            _context.CallForPapers.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CallForPaper itemToUpdate)
        {
            _context.CallForPapers.Update(itemToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
