using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class IgrejaService : IIgrejaService
    {
        private readonly IIgrejaRepository _igrejaRepository;
        private readonly IMapper _mapper;

        public IgrejaService(IIgrejaRepository igrejaRepository, IMapper mapper)
        {
            _igrejaRepository = igrejaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(IgrejaVm igrejaVm)
        {
            var igreja = _mapper.Map<Igreja>(igrejaVm);
            await _igrejaRepository.AddAsync(igreja);
        }
     

        public async Task<(IEnumerable<IgrejaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<IgrejaVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Igreja, bool>>>(filtragem);
            var (lista, count) = await _igrejaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<IgrejaVm>>(lista), count);
        }

        public async Task<IgrejaVm?> GetByIdAsync(Guid igrejaId)
        {
            return _mapper.Map<IgrejaVm>(await _igrejaRepository.GetByIdAsync(igrejaId));
        }
              

        public async Task UpdateAsync(IgrejaVm igrejaVm)
        {
            Igreja result = _mapper.Map<Igreja>(igrejaVm);
            await _igrejaRepository.Update(result);
        }

        public async Task<IgrejaVm> Remover(Guid igrejaId)
        {
            var result = await _igrejaRepository.GetByIdAsync(igrejaId);
            if (result != null)
            {
                _igrejaRepository.Remover(result);
            }

            return _mapper.Map<IgrejaVm>(result);
        }

        public async Task<IgrejaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<IgrejaVm, bool>>? expression = null)
        {
            var result = await _igrejaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Igreja, bool>>>(expression));
            return _mapper.Map<IgrejaVm>(result);
        }

        public async Task<IEnumerable<IgrejaVm>> GetAllAsync(Expression<Func<IgrejaVm, bool>>? expression = null, params Expression<Func<IgrejaVm, object?>>[]? includes)
        {
            var result = await _igrejaRepository.GetAllAsync(
                                  _mapper.Map<Expression<Func<Igreja, bool>>>(expression),
                                  _mapper.Map<Expression<Func<Igreja, object>>[]>(includes));
            return _mapper.Map<IEnumerable<IgrejaVm>>(result);
        }

        public async Task InativarAsync(Guid id)
        {
            await _igrejaRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _igrejaRepository.ReativarAsync(id);
        }
    }
}
