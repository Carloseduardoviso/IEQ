using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Services.Interfaces
{
    public class PastoresService : IPastoresService
    {
        private readonly IPastoresRepository _pastoresRepository;
        private readonly IMapper _mapper;

        public PastoresService(IPastoresRepository pastoresRepository, IMapper mapper)
        {
            _pastoresRepository = pastoresRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PastoresVm vm)
        {
            var result = _mapper.Map<Pastores>(vm);
            await _pastoresRepository.AddAsync(result);
        }

        public async Task<IEnumerable<PastoresVm>> GetAllAsync(Expression<Func<PastoresVm, bool>>? expression = null, params Expression<Func<PastoresVm, object?>>[]? includes)
        {
            var result = await _pastoresRepository.GetAllAsync(
                                  _mapper.Map<Expression<Func<Pastores, bool>>>(expression),
                                  _mapper.Map<Expression<Func<Pastores, object>>[]>(includes));
            return _mapper.Map<IEnumerable<PastoresVm>>(result);
        }

        public async Task<(IEnumerable<PastoresVm> lista, int count)> GetAllPaginationAsync(Expression<Func<PastoresVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Pastores, bool>>>(filtragem);
            var (lista, count) = await _pastoresRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<PastoresVm>>(lista), count);
        }

        public async Task<PastoresVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<PastoresVm, bool>>? expression = null)
        {
            var result = await _pastoresRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Pastores, bool>>>(expression));
            return _mapper.Map<PastoresVm>(result);
        }

        public async Task<PastoresVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<PastoresVm>(await _pastoresRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _pastoresRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _pastoresRepository.ReativarAsync(id);
        }

        public async Task<PastoresVm> Remover(Guid id)
        {
            var result = await _pastoresRepository.GetByIdAsync(id);
            if (result != null)
            {
                _pastoresRepository.Remover(result);
            }

            return _mapper.Map<PastoresVm>(result);
        }

        public async Task UpdateAsync(PastoresVm vm)
        {
            Pastores result = _mapper.Map<Pastores>(vm);
            await _pastoresRepository.Update(result);
        }
    }
}
