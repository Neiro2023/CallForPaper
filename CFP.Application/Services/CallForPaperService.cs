using CFP.Application.DTOs;
using CFP.Application.Exceptions;
using CFP.Application.Mappers;
using CFP.Application.Services.Repos;
using CFP.DataAccess.Entities;

namespace CFP.Application.Services
{
    public class CallForPaperService : ICallForPaperService
    {
        private readonly ICallForPaperRepo _repo;
        private readonly CallForPaperMapper _mapper;

        public CallForPaperService(ICallForPaperRepo repo, CallForPaperMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CallForPaperRequest request)
        {
            var callForPapers = await _repo.Get();
            var draft = callForPapers.FirstOrDefault(x => x.Status == Status.Draft && x.UserId == request.UserId);
            if (draft != null)
            {
                throw new CallForPaperException(400, "У пользователя может быть только один черновик");
            }
            var callForPaper = _mapper.MapFrom(request);
            return await _repo.Create(callForPaper);
        }

        public List<ActivityType> GetActivities()
        {
            return Enum.GetValues<ActivityType>().ToList();
        }

        public async Task<CallForPaperResponse> GetById(Guid id)
        {
            var callForPaper = await _repo.GetById(id);
            if (callForPaper != null)
            {
                return _mapper.MapFrom(callForPaper);
            }

            throw new CallForPaperException(400, "Заявка не найдена");
        }

        public async Task<List<CallForPaperResponse>> GetDrafts(DateTime date)
        {
            List<CallForPaperResponse> response = new();
            date = date.ToUniversalTime();

            var callForPapers = await _repo.Get();
            foreach (var item in callForPapers)
            {
                if (item.Status == Status.Draft && item.CreateDate >= date)
                {
                    response.Add(_mapper.MapFrom(item));
                }
            }

            return response;
        }

        public async Task<List<CallForPaperResponse>> GetSended(DateTime date)
        {
            List<CallForPaperResponse> response = new();
            date = date.ToUniversalTime();

            var callForPapers = await _repo.Get();
            foreach (var item in callForPapers)
            {
                if (item.Status == Status.Sended && item.SubmitDate >= date)
                {
                    response.Add(_mapper.MapFrom(item));
                }
            }

            return response;
        }

        public async Task<CallForPaperResponse> GetUserDraft(Guid userId)
        {
            var callForPapers = await _repo.Get();
            var response = callForPapers.FirstOrDefault(x => x.Status == Status.Draft && x.UserId == userId);
            if (response != null)
            {
                return _mapper.MapFrom(response);
            }

            throw new CallForPaperException(400, "Для переданного пользователя не найдена не поданная заявка");
        }

        public async Task Remove(Guid id)
        {
            var itemToRemove = await _repo.GetById(id);
            if (itemToRemove != null)
            {
                if (itemToRemove.Status == Status.Sended)
                {
                    throw new CallForPaperException(400, "Нельзя удалить/отменить отправленную заявку");
                }
                await _repo.Remove(itemToRemove);
                return;
            }

            throw new CallForPaperException(400, "Заявка не найдена");
        }

        public async Task SendForReview(Guid id)
        {
            var itemToReview = await _repo.GetById(id);
            if (itemToReview != null)
            {
                itemToReview.Submit();
                await _repo.Update(itemToReview);
                return;
            }

            throw new CallForPaperException(400, "Заявка не найдена");
        }

        public async Task Update(Guid id, CallForPaperRequest request)
        {
            var itemToUpdate = await _repo.GetById(id);
            if (itemToUpdate != null)
            {
                if (itemToUpdate.Status == Status.Sended)
                {
                    throw new CallForPaperException(400, "Нельзя редактировать отправленную заявку");
                }
                var callForPaper = _mapper.MapFrom(request);
                itemToUpdate.Set(callForPaper);
                await _repo.Update(itemToUpdate);
                return;
            }

            throw new CallForPaperException(400, "Заявка не найдена");
        }
    }
}
