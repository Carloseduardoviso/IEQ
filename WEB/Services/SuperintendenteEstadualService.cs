using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class SuperintendenteEstadualService : ISuperintendenteEstadualService
    {
        private readonly ISuperintendenteEstadualRepository _superintendenteEstadualRepository;
        private readonly IMapper _mapper;

        public SuperintendenteEstadualService(ISuperintendenteEstadualRepository superintendenteEstadualRepository, IMapper mapper)
        {
            _superintendenteEstadualRepository = superintendenteEstadualRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SuperintendenteEstadualVm vm)
        {
            var result = _mapper.Map<SuperintendenteEstadual>(vm);
            await _superintendenteEstadualRepository.AddAsync(result);
        }

        public async Task<IEnumerable<SuperintendenteEstadualVm>> GetAllAsync(Expression<Func<SuperintendenteEstadualVm, bool>>? expression = null, params Expression<Func<SuperintendenteEstadualVm, object?>>[]? includes)
        {
            var result = await _superintendenteEstadualRepository.GetAllAsync(
                                  _mapper.Map<Expression<Func<SuperintendenteEstadual, bool>>>(expression),
                                  _mapper.Map<Expression<Func<SuperintendenteEstadual, object>>[]>(includes));
            return _mapper.Map<IEnumerable<SuperintendenteEstadualVm>>(result);
        }

        public async Task<(IEnumerable<SuperintendenteEstadualVm> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteEstadualVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<SuperintendenteEstadual, bool>>>(filtragem);
            var (lista, count) = await _superintendenteEstadualRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<SuperintendenteEstadualVm>>(lista), count);
        }

        public async Task<SuperintendenteEstadualVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteEstadualVm, bool>>? expression = null)
        {
            var result = await _superintendenteEstadualRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<SuperintendenteEstadual, bool>>>(expression));
            return _mapper.Map<SuperintendenteEstadualVm>(result);
        }

        public async Task<SuperintendenteEstadualVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<SuperintendenteEstadualVm>(await _superintendenteEstadualRepository.GetByIdAsync(id));
        }

        public async Task<SuperintendenteEstadualVm> Remover(Guid id)
        {
            var result = await _superintendenteEstadualRepository.GetByIdAsync(id);
            if (result != null)
            {
                _superintendenteEstadualRepository.Remover(result);
            }

            return _mapper.Map<SuperintendenteEstadualVm>(result);
        }

        public async Task Update(SuperintendenteEstadualVm vm)
        {
            SuperintendenteEstadual result = _mapper.Map<SuperintendenteEstadual>(vm);
            await _superintendenteEstadualRepository.Update(result);
        }
    }
}
