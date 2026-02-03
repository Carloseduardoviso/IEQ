using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class SuperintendenteRegionalService : ISuperintendenteRegionalService
    {
        private readonly ISuperintendenteRegionalRepository _superintendenteRegionalRepository;
        private readonly IMapper _mapper;

        public SuperintendenteRegionalService(ISuperintendenteRegionalRepository superintendenteRegionalRepository, IMapper mapper)
        {
            _superintendenteRegionalRepository = superintendenteRegionalRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SuperintendenteRegionalVm vm)
        {
            var result = _mapper.Map<SuperintendenteRegional>(vm);
            await _superintendenteRegionalRepository.AddAsync(result);
        }

        public async Task<IEnumerable<SuperintendenteRegionalVm>> GetAllAsync(Expression<Func<SuperintendenteRegionalVm, bool>>? expression = null, params Expression<Func<SuperintendenteRegionalVm, object?>>[]? includes)
        {
            var result = await _superintendenteRegionalRepository.GetAllAsync(
                                  _mapper.Map<Expression<Func<SuperintendenteRegional, bool>>>(expression),
                                  _mapper.Map<Expression<Func<SuperintendenteRegional, object>>[]>(includes));
            return _mapper.Map<IEnumerable<SuperintendenteRegionalVm>>(result);
        }

        public async Task<(IEnumerable<SuperintendenteRegionalVm> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteRegionalVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<SuperintendenteRegional, bool>>>(filtragem);
            var (lista, count) = await _superintendenteRegionalRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<SuperintendenteRegionalVm>>(lista), count);
        }

        public async Task<SuperintendenteRegionalVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteRegionalVm, bool>>? expression = null)
        {
            var result = await _superintendenteRegionalRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<SuperintendenteRegional, bool>>>(expression));
            return _mapper.Map<SuperintendenteRegionalVm>(result);
        }

        public async Task<SuperintendenteRegionalVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<SuperintendenteRegionalVm>(await _superintendenteRegionalRepository.GetByIdAsync(id));
        }

        public async Task<SuperintendenteRegionalVm> Remover(Guid id)
        {
            var result = await _superintendenteRegionalRepository.GetByIdAsync(id);
            if (result != null)
            {
                _superintendenteRegionalRepository.Remover(result);
            }

            return _mapper.Map<SuperintendenteRegionalVm>(result);
        }

        public async Task UpdateAsync(SuperintendenteRegionalVm vm)
        {
            SuperintendenteRegional result = _mapper.Map<SuperintendenteRegional>(vm);
            await _superintendenteRegionalRepository.Update(result);
        }
    }
}
