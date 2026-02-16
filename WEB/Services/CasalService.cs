using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class CasalService : ICasalService
    {
        private readonly ICasalRepository _casalRepository;
        private readonly IMapper _mapper;

        public CasalService(ICasalRepository casalRepository, IMapper mapper)
        {
            _casalRepository = casalRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CasalVm vm)
        {
            var result = _mapper.Map<Casal>(vm);
            await _casalRepository.AddAsync(result);
        }

        public async Task<IEnumerable<CasalVm>> GetAllAsync(Expression<Func<CasalVm, bool>>? expression = null, params Expression<Func<CasalVm, object?>>[]? includes)
        {
            var result = await _casalRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Casal, bool>>>(expression),
             _mapper.Map<Expression<Func<Casal, object>>[]>(includes));
            return _mapper.Map<IEnumerable<CasalVm>>(result);
        }

        public async Task<(IEnumerable<CasalVm> lista, int count)> GetAllPaginationAsync(Expression<Func<CasalVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Casal, bool>>>(filtragem);
            var (lista, count) = await _casalRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CasalVm>>(lista), count);
        }

        public async Task<CasalVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<CasalVm, bool>>? expression = null)
        {
            var result = await _casalRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Casal, bool>>>(expression));
            return _mapper.Map<CasalVm>(result);
        }

        public async Task<CasalVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CasalVm>(await _casalRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _casalRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        { 
            await _casalRepository.ReativarAsync(id);
        }

        public Task<CasalVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CasalVm vm)
        {
            Casal result = _mapper.Map<Casal>(vm);
            await _casalRepository.Update(result);
        }
    }
}
