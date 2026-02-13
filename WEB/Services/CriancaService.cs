using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class CriancaService : ICriancaService
    {
        private readonly ICriancaRepository _criancaRepository;
        private readonly IMapper _mapper;

        public CriancaService(ICriancaRepository criancaRepository, IMapper mapper)
        {
            _criancaRepository = criancaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CriancaVm vm)
        {
            var result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.AddAsync(result);
        }

        public async Task<IEnumerable<CriancaVm>> GetAllAsync(Expression<Func<CriancaVm, bool>>? expression = null, params Expression<Func<CriancaVm, object?>>[]? includes)
        {
            var result = await _criancaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Crianca, bool>>>(expression),
             _mapper.Map<Expression<Func<Crianca, object>>[]>(includes));
            return _mapper.Map<IEnumerable<CriancaVm>>(result);
        }

        public async Task<(IEnumerable<CriancaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<CriancaVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public async Task<CriancaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<CriancaVm, bool>>? expression = null)
        {
            var result = await _criancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Crianca, bool>>>(expression));
            return _mapper.Map<CriancaVm>(result);
        }

        public async Task<CriancaVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CriancaVm>(await _criancaRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _criancaRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        { 
            await _criancaRepository.ReativarAsync(id);
        }

        public Task<CriancaVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CriancaVm vm)
        {
            Crianca result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.Update(result);
        }
    }
}
