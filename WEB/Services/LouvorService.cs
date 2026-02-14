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

        public async Task AddAsync(LouvorVm vm)
        {
            var result = _mapper.Map<Louvor>(vm);
            await _louvorRepository.AddAsync(result);
        }

        public async Task<IEnumerable<LouvorVm>> GetAllAsync(Expression<Func<LouvorVm, bool>>? expression = null, params Expression<Func<LouvorVm, object?>>[]? includes)
        {
            var result = await _louvorRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Louvor, bool>>>(expression),
             _mapper.Map<Expression<Func<Louvor, object>>[]>(includes));
            return _mapper.Map<IEnumerable<LouvorVm>>(result);
        }

        public async Task<(IEnumerable<LouvorVm> lista, int count)> GetAllPaginationAsync(Expression<Func<LouvorVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Louvor, bool>>>(filtragem);
            var (lista, count) = await _louvorRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<LouvorVm>>(lista), count);
        }

        public async Task<LouvorVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<LouvorVm, bool>>? expression = null)
        {
            var result = await _louvorRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Louvor, bool>>>(expression));
            return _mapper.Map<LouvorVm>(result);
        }

        public async Task<LouvorVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<LouvorVm>(await _louvorRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _louvorRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _louvorRepository.ReativarAsync(id);
        }

        public async Task<LouvorVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LouvorVm vm)
        {
            Louvor result = _mapper.Map<Louvor>(vm);
            await _louvorRepository.Update(result);
        }
    }
}
