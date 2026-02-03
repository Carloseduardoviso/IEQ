using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly IRegiaoRepository _regiaoRepository;
        private readonly IMapper _mapper;

        public RegiaoService(IRegiaoRepository regiaoRepository, IMapper mapper)
        {
            _regiaoRepository = regiaoRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(RegiaoVm vm)
        {
            var result = _mapper.Map<Regiao>(vm);
            await _regiaoRepository.AddAsync(result);
        }

        public async Task<IEnumerable<RegiaoVm>> GetAllAsync(Expression<Func<RegiaoVm, bool>>? expression = null, params Expression<Func<RegiaoVm, object?>>[]? includes)
        {
            var result = await _regiaoRepository.GetAllAsync(
                                  _mapper.Map<Expression<Func<Regiao, bool>>>(expression),
                                  _mapper.Map<Expression<Func<Regiao, object>>[]>(includes));
            return _mapper.Map<IEnumerable<RegiaoVm>>(result);
        }

        public async Task<(IEnumerable<RegiaoVm> lista, int count)> GetAllPaginationAsync(Expression<Func<RegiaoVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Regiao, bool>>>(filtragem);
            var (lista, count) = await _regiaoRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<RegiaoVm>>(lista), count);
        }      

        public async Task<RegiaoVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<RegiaoVm, bool>>? expression = null)
        {
            var result = await _regiaoRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Regiao, bool>>>(expression));
            return _mapper.Map<RegiaoVm>(result);
        }

        public async Task<RegiaoVm> GetByIdAsync(Guid regiaoId)
        {
            return _mapper.Map<RegiaoVm>(await _regiaoRepository.GetByIdAsync(regiaoId));
        }

        public async Task<RegiaoVm> Remover(Guid regiaoId)
        {
            var result = await _regiaoRepository.GetByIdAsync(regiaoId);
            if (result != null)
            {
                _regiaoRepository.Remover(result);
            }

            return _mapper.Map<RegiaoVm>(result);
        }

        public async Task UpdateAsync(RegiaoVm vm)
        {
            Regiao result = _mapper.Map<Regiao>(vm);
            await _regiaoRepository.Update(result);
        }
    }
}
