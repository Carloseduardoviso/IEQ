using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class TeatroService : ITeatroService
    {
        private readonly ITeatroRepository _teatroRepository;
        private readonly IMapper _mapper;

        public TeatroService(ITeatroRepository teatroRepository, IMapper mapper)
        {
            _teatroRepository = teatroRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TeatroVm vm)
        {
            var result = _mapper.Map<Teatro>(vm);
            await _teatroRepository.AddAsync(result);
        }

        public async Task<IEnumerable<TeatroVm>> GetAllAsync(Expression<Func<TeatroVm, bool>>? expression = null, params Expression<Func<TeatroVm, object?>>[]? includes)
        {
            var result = await _teatroRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Teatro, bool>>>(expression),
             _mapper.Map<Expression<Func<Teatro, object>>[]>(includes));
            return _mapper.Map<IEnumerable<TeatroVm>>(result);
        }

        public async Task<(IEnumerable<TeatroVm> lista, int count)> GetAllPaginationAsync(Expression<Func<TeatroVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Teatro, bool>>>(filtragem);
            var (lista, count) = await _teatroRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<TeatroVm>>(lista), count);
        }

        public async Task<TeatroVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<TeatroVm, bool>>? expression = null)
        {
            var result = await _teatroRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Teatro, bool>>>(expression));
            return _mapper.Map<TeatroVm>(result);
        }

        public async Task<TeatroVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<TeatroVm>(await _teatroRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _teatroRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _teatroRepository.ReativarAsync(id);
        }

        public async Task<TeatroVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TeatroVm vm)
        {
            Teatro result = _mapper.Map<Teatro>(vm);
            await _teatroRepository.Update(result);
        }
    }
}