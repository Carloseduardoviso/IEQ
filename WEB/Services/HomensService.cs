using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class HomensService : IHomensService
    {
        private readonly IHomensRepository _homensRepository;
        private readonly IMapper _mapper;

        public HomensService(IHomensRepository homensRepository, IMapper mapper)
        {
            _homensRepository = homensRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(HomensVm vm)
        {
            var result = _mapper.Map<Homens>(vm);
            await _homensRepository.AddAsync(result);
        }

        public async Task<IEnumerable<HomensVm>> GetAllAsync(Expression<Func<HomensVm, bool>>? expression = null, params Expression<Func<HomensVm, object?>>[]? includes)
        {
            var result = await _homensRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Homens, bool>>>(expression),
             _mapper.Map<Expression<Func<Homens, object>>[]>(includes));
            return _mapper.Map<IEnumerable<HomensVm>>(result);
        }

        public async Task<(IEnumerable<HomensVm> lista, int count)> GetAllPaginationAsync(Expression<Func<HomensVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Homens, bool>>>(filtragem);
            var (lista, count) = await _homensRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<HomensVm>>(lista), count);
        }

        public async Task<HomensVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<HomensVm, bool>>? expression = null)
        {
            var result = await _homensRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Homens, bool>>>(expression));
            return _mapper.Map<HomensVm>(result);
        }

        public async Task<HomensVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<HomensVm>(await _homensRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _homensRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _homensRepository.ReativarAsync(id);
        }

        public async Task<HomensVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(HomensVm vm)
        {
            Homens result = _mapper.Map<Homens>(vm);
            await _homensRepository.Update(result);
        }
    }
}
