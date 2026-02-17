using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class MembroService : IMembroService
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IMapper _mapper;

        public MembroService(IMembroRepository membroRepository, IMapper mapper)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(MembroVm vm)
        {
            var result = _mapper.Map<Membro>(vm);
            await _membroRepository.AddAsync(result);
        }

        public async Task<IEnumerable<MembroVm>> GetAllAsync(Expression<Func<MembroVm, bool>>? expression = null, params Expression<Func<MembroVm, object?>>[]? includes)
        {
            var result = await _membroRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Membro, bool>>>(expression),
             _mapper.Map<Expression<Func<Membro, object>>[]>(includes));
            return _mapper.Map<IEnumerable<MembroVm>>(result);
        }

        public async Task<(IEnumerable<MembroVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MembroVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Membro, bool>>>(filtragem);
            var (lista, count) = await _membroRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<MembroVm>>(lista), count);
        }

        public async Task<MembroVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MembroVm, bool>>? expression = null)
        {
            var result = await _membroRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Membro, bool>>>(expression));
            return _mapper.Map<MembroVm>(result);
        }

        public async Task<MembroVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<MembroVm>(await _membroRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _membroRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        { 
            await _membroRepository.ReativarAsync(id);
        }

        public Task<MembroVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(MembroVm vm)
        {
            Membro result = _mapper.Map<Membro>(vm);
            await _membroRepository.Update(result);
        }
    }
}
