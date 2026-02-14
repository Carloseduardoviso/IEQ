using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class DancaService : IDancaService
    {
        private readonly IDancaRepository _dancaRepository;
        private readonly IMapper _mapper;

        public DancaService(IDancaRepository dancaRepository, IMapper mapper)
        {
            _dancaRepository = dancaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(DancaVm vm)
        {
            var result = _mapper.Map<Danca>(vm);
            await _dancaRepository.AddAsync(result);
        }

        public async Task<IEnumerable<DancaVm>> GetAllAsync(Expression<Func<DancaVm, bool>>? expression = null, params Expression<Func<DancaVm, object?>>[]? includes)
        {
            var result = await _dancaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Danca, bool>>>(expression),
             _mapper.Map<Expression<Func<Danca, object>>[]>(includes));
            return _mapper.Map<IEnumerable<DancaVm>>(result);
        }

        public async Task<(IEnumerable<DancaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<DancaVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Danca, bool>>>(filtragem);
            var (lista, count) = await _dancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<DancaVm>>(lista), count);
        }

        public async Task<DancaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<DancaVm, bool>>? expression = null)
        {
            var result = await _dancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Danca, bool>>>(expression));
            return _mapper.Map<DancaVm>(result);
        }

        public async Task<DancaVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<DancaVm>(await _dancaRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _dancaRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _dancaRepository.ReativarAsync(id);
        }

        public Task<DancaVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DancaVm vm)
        {
            Danca result = _mapper.Map<Danca>(vm);
            await _dancaRepository.Update(result);
        }
    }
}
