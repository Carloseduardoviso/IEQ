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

        public Task AddAsync(TeatroVm vm)
        {
            var result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.AddAsync(result);
        }

        public Task<IEnumerable<TeatroVm>> GetAllAsync(Expression<Func<TeatroVm, bool>>? expression = null, params Expression<Func<TeatroVm, object?>>[]? includes)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public Task<(IEnumerable<TeatroVm> lista, int count)> GetAllPaginationAsync(Expression<Func<TeatroVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public Task<TeatroVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<TeatroVm, bool>>? expression = null)
        {
            var result = await _criancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Crianca, bool>>>(expression));
            return _mapper.Map<CriancaVm>(result);
        }

        public Task<TeatroVm> GetByIdAsync(Guid id)
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

        public Task<TeatroVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TeatroVm vm)
        {
            Crianca result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.Update(result);
        }
    }
}