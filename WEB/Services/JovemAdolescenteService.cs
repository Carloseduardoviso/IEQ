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
        private readonly IJovemAdolescenteRepository _repository;
        private readonly IMapper _mapper;

        public JovemAdolescenteService(IJovemAdolescenteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task AddAsync(JovemAdolescenteVm vm)
        {
            var result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.AddAsync(result);
        }

        public Task<IEnumerable<JovemAdolescenteVm>> GetAllAsync(Expression<Func<JovemAdolescenteVm, bool>>? expression = null, params Expression<Func<JovemAdolescenteVm, object?>>[]? includes)
        {
            var result = await _criancaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Crianca, bool>>>(expression),
             _mapper.Map<Expression<Func<Crianca, object>>[]>(includes));
            return _mapper.Map<IEnumerable<CriancaVm>>(result);
        }

        public Task<(IEnumerable<JovemAdolescenteVm> lista, int count)> GetAllPaginationAsync(Expression<Func<JovemAdolescenteVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public Task<JovemAdolescenteVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<JovemAdolescenteVm, bool>>? expression = null)
        {
            var result = await _criancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Crianca, bool>>>(expression));
            return _mapper.Map<CriancaVm>(result);
        }

        public Task<JovemAdolescenteVm> GetByIdAsync(Guid id)
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

        public Task<JovemAdolescenteVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(JovemAdolescenteVm vm)
        {
            Crianca result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.Update(result);
        }
    }
}
