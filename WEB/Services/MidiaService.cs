using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class MidiaService : IMidiaService
    {
        private readonly IMidiaRepository _midiaRepository;
        private readonly IMapper _mapper;

        public MidiaService(IMidiaRepository midiaRepository, IMapper mapper)
        {
            _midiaRepository = midiaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(MidiaVm vm)
        {
            var result = _mapper.Map<Midia>(vm);
            await _midiaRepository.AddAsync(result);
        }

        public async Task<IEnumerable<MidiaVm>> GetAllAsync(Expression<Func<MidiaVm, bool>>? expression = null, params Expression<Func<MidiaVm, object?>>[]? includes)
        {
            var result = await _midiaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Midia, bool>>>(expression),
             _mapper.Map<Expression<Func<Midia, object>>[]>(includes));
            return _mapper.Map<IEnumerable<MidiaVm>>(result);
        }

        public async Task<(IEnumerable<MidiaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MidiaVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Midia, bool>>>(filtragem);
            var (lista, count) = await _midiaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<MidiaVm>>(lista), count);
        }

        public async Task<MidiaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MidiaVm, bool>>? expression = null)
        {
            var result = await _midiaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Midia, bool>>>(expression));
            return _mapper.Map<MidiaVm>(result);
        }

        public async Task<MidiaVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<MidiaVm>(await _midiaRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _midiaRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _midiaRepository.ReativarAsync(id);
        }

        public async Task<MidiaVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(MidiaVm vm)
        {
            Midia result = _mapper.Map<Midia>(vm);
            await _midiaRepository.Update(result);
        }
    }
}
