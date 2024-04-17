using CFP.Application.DTOs;
using CFP.Application.Services;
using CFP.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallForPaperController : Controller
    {
        private readonly ICallForPaperService _service;

        public CallForPaperController(ICallForPaperService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<Guid> Create(CallForPaperRequest request)
        {
            return await _service.Create(request);
        }

        [HttpPost("{id}/Submit")]
        public async Task SendForReview(Guid id)
        {
            await _service.SendForReview(id);
        }

        [HttpGet("{id}")]
        public async Task<CallForPaperResponse> GetById(Guid id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("{userId}/Draft")]
        public async Task<CallForPaperResponse> GetUserDraft(Guid userId)
        {
            return await _service.GetUserDraft(userId);
        }

        [HttpGet("Activities")]
        public async Task<List<ActivityType>> GetActivities()
        {
            return await Task.Run(() => _service.GetActivities());
        }

        [HttpGet("{date}/Sended")]
        public async Task<List<CallForPaperResponse>> GetSended(DateTime date)
        {
            return await _service.GetSended(date);
        }

        [HttpGet("{date}/Drafts")]
        public async Task<List<CallForPaperResponse>> GetDrafts(DateTime date)
        {
            return await _service.GetDrafts(date);
        }

        [HttpPut("{id}")]
        public async Task Update(Guid id, CallForPaperRequest request)
        {
            await _service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task Remove(Guid id)
        {
            await _service.Remove(id);
        }
    }
}
