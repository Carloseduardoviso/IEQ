using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class GerenciamentoService : IGerenciamentoService
    {
        public readonly IGerenciamentoRepository _gerenciamentoRepository;
        public readonly IMapper _mapper;

        public GerenciamentoService(IGerenciamentoRepository gerenciamentoRepository, IMapper mapper)
        {
            _gerenciamentoRepository = gerenciamentoRepository;
            _mapper = mapper;
        }

        public async Task<IgrejaVm?> GetByIdIgrejaAsync(Guid igrejaId, params Expression<Func<IgrejaVm, object?>>[]? includes)
        {
            var include = _mapper.Map<Expression<Func<Igreja, object?>>[]>(includes);
            return _mapper.Map<IgrejaVm>(await _gerenciamentoRepository.GetByIdIgrejaAsync(igrejaId, include ?? null));
        }

        public async Task<PastoresVm?> GetByIdPastoresAsync(Guid pasteresId, params Expression<Func<PastoresVm, object?>>[]? includes)
        {
            var include = _mapper.Map<Expression<Func<Pastores, object?>>[]>(includes);
            return _mapper.Map<PastoresVm>(await _gerenciamentoRepository.GetByIdPastoresAsync(pasteresId, include ?? null));
        }

        public async Task<RegiaoVm?> GetByIdRegiaoAsync(Guid regiaoId, params Expression<Func<RegiaoVm, object?>>[]? includes)
        {
            var include = _mapper.Map<Expression<Func<Regiao, object?>>[]>(includes);
            return _mapper.Map<RegiaoVm>(await _gerenciamentoRepository.GetByIdRegiaoAsync(regiaoId, include ?? null));
        }

        public async Task<SuperintendenteEstadualVm?> GetByIdSuperintendenteEstadualAsync(Guid superintendenteEstadualId, params Expression<Func<SuperintendenteEstadualVm, object?>>[]? includes)
        {
            var include = _mapper.Map<Expression<Func<SuperintendenteEstadual, object?>>[]>(includes);
            return _mapper.Map<SuperintendenteEstadualVm>(await _gerenciamentoRepository.GetByIdSuperintendenteEstadualAsync(superintendenteEstadualId, include ?? null));
        }

        public async Task<SuperintendenteRegionalVm?> GetByIdSuperintendenteRegionalAsync(Guid superintendenteRegionalid, params Expression<Func<SuperintendenteRegionalVm, object?>>[]? includes)
        {
            var include = _mapper.Map<Expression<Func<SuperintendenteRegional, object?>>[]>(includes);
            return _mapper.Map<SuperintendenteRegionalVm>(await _gerenciamentoRepository.GetByIdSuperintendenteRegionalAsync(superintendenteRegionalid, include ?? null));
        }
    }
}
