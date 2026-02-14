using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class MulheresService : IMulheresService
    {
        private readonly IMulheresRepository _mulheresRepository;
        private readonly IMapper _mapper;

        public MulheresService(IMulheresRepository mulheresRepository, IMapper mapper)
        {
            _mulheresRepository = mulheresRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(MulheresVm vm)
        {
            var result = _mapper.Map<Mulheres>(vm);
            await _mulheresRepository.AddAsync(result);
        }

        public async Task<IEnumerable<MulheresVm>> GetAllAsync(Expression<Func<MulheresVm, bool>>? expression = null, params Expression<Func<MulheresVm, object?>>[]? includes)
        {
            var result = await _mulheresRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Mulheres, bool>>>(expression),
             _mapper.Map<Expression<Func<Mulheres, object>>[]>(includes));
            return _mapper.Map<IEnumerable<MulheresVm>>(result);
        }

        public async Task<(IEnumerable<MulheresVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MulheresVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Mulheres, bool>>>(filtragem);
            var (lista, count) = await _mulheresRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<MulheresVm>>(lista), count);
        }

        public async Task<MulheresVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MulheresVm, bool>>? expression = null)
        {
            var result = await _mulheresRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Mulheres, bool>>>(expression));
            return _mapper.Map<MulheresVm>(result);
        }

        public async Task<MulheresVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<MulheresVm>(await _mulheresRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        { 
            await _mulheresRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _mulheresRepository.ReativarAsync(id);
        }

        public async Task<MulheresVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(MulheresVm vm)
        {
            Mulheres result = _mapper.Map<Mulheres>(vm);
            await _mulheresRepository.Update(result);
        }
    }
}
