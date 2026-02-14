using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class JovemAdolescenteService : IJovemAdolescenteService
    {
        private readonly IJovemAdolescenteRepository _jovemAdolescenteRepository;
        private readonly IMapper _mapper;

        public JovemAdolescenteService(IJovemAdolescenteRepository jovemAdolescenteRepository, IMapper mapper)
        {
            _jovemAdolescenteRepository = jovemAdolescenteRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(JovemAdolescenteVm vm)
        {
            var result = _mapper.Map<JovemAdolescente>(vm);
            await _jovemAdolescenteRepository.AddAsync(result);
        }

        public async Task<IEnumerable<JovemAdolescenteVm>> GetAllAsync(Expression<Func<JovemAdolescenteVm, bool>>? expression = null, params Expression<Func<JovemAdolescenteVm, object?>>[]? includes)
        {
            var result = await _jovemAdolescenteRepository.GetAllAsync(
             _mapper.Map<Expression<Func<JovemAdolescente, bool>>>(expression),
             _mapper.Map<Expression<Func<JovemAdolescente, object>>[]>(includes));
            return _mapper.Map<IEnumerable<JovemAdolescenteVm>>(result);
        }

        public async Task<(IEnumerable<JovemAdolescenteVm> lista, int count)> GetAllPaginationAsync(Expression<Func<JovemAdolescenteVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<JovemAdolescente, bool>>>(filtragem);
            var (lista, count) = await _jovemAdolescenteRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<JovemAdolescenteVm>>(lista), count);
        }

        public async Task<JovemAdolescenteVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<JovemAdolescenteVm, bool>>? expression = null)
        {
            var result = await _jovemAdolescenteRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<JovemAdolescente, bool>>>(expression));
            return _mapper.Map<JovemAdolescenteVm>(result);
        }

        public async Task<JovemAdolescenteVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<JovemAdolescenteVm>(await _jovemAdolescenteRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _jovemAdolescenteRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _jovemAdolescenteRepository.ReativarAsync(id);
        }

        public async Task<JovemAdolescenteVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(JovemAdolescenteVm vm)
        {
            JovemAdolescente result = _mapper.Map<JovemAdolescente>(vm);
            await _jovemAdolescenteRepository.Update(result);
        }
    }
}
