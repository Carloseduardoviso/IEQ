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

        public Task AddAsync(MulheresVm vm)
        {
            var result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.AddAsync(result);
        }

        public Task<IEnumerable<MulheresVm>> GetAllAsync(Expression<Func<MulheresVm, bool>>? expression = null, params Expression<Func<MulheresVm, object?>>[]? includes)
        {
            var result = await _criancaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Crianca, bool>>>(expression),
             _mapper.Map<Expression<Func<Crianca, object>>[]>(includes));
            return _mapper.Map<IEnumerable<CriancaVm>>(result);
        }

        public Task<(IEnumerable<MulheresVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MulheresVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public Task<MulheresVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MulheresVm, bool>>? expression = null)
        {
            var result = await _criancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Crianca, bool>>>(expression));
            return _mapper.Map<CriancaVm>(result);
        }

        public Task<MulheresVm> GetByIdAsync(Guid id)
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

        public Task<MulheresVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MulheresVm vm)
        {
            Crianca result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.Update(result);
        }
    }
}
