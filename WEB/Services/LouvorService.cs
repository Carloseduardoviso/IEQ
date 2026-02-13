using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class LouvorService : ILouvorService
    {
        private readonly ILouvorRepository _louvorRepository;
        private readonly IMapper _mapper;

        public LouvorService(ILouvorRepository louvorRepository, IMapper mapper)
        {
            _louvorRepository = louvorRepository;
            _mapper = mapper;
        }

        public Task AddAsync(LouvorVm vm)
        {
            var result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.AddAsync(result);
        }

        public Task<IEnumerable<LouvorVm>> GetAllAsync(Expression<Func<LouvorVm, bool>>? expression = null, params Expression<Func<LouvorVm, object?>>[]? includes)
        {
            var result = await _criancaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Crianca, bool>>>(expression),
             _mapper.Map<Expression<Func<Crianca, object>>[]>(includes));
            return _mapper.Map<IEnumerable<CriancaVm>>(result);
        }

        public Task<(IEnumerable<LouvorVm> lista, int count)> GetAllPaginationAsync(Expression<Func<LouvorVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public Task<LouvorVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<LouvorVm, bool>>? expression = null)
        {
            var result = await _criancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Crianca, bool>>>(expression));
            return _mapper.Map<CriancaVm>(result);
        }

        public Task<LouvorVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CriancaVm>(await _criancaRepository.GetByIdAsync(id));
        }

        public Task InativarAsync(Guid id)
        {
            await _criancaRepository.InativarAsync(id);
        }

        public Task ReativarAsync(Guid id)
        {
            await _criancaRepository.ReativarAsync(id);
        }

        public Task<LouvorVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(LouvorVm vm)
        {
            Crianca result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.Update(result);
        }
    }
}
