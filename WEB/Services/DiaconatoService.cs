using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class DiaconatoService : IDiaconatoService
    {
        public readonly IDiaconatoRepository _diaconatoRepository;
        public readonly IMapper _mapper;

        public DiaconatoService(IDiaconatoRepository diaconatoRepository, IMapper mapper)
        {
            _diaconatoRepository = diaconatoRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(DiaconatoVm diaconatoVm)
        {
            var diaconato = _mapper.Map<Diaconato>(diaconatoVm);
            await _diaconatoRepository.AddAsync(diaconato);
        }

        public async Task<IEnumerable<DiaconatoVm>> GetAllAsync(Expression<Func<DiaconatoVm, bool>>? expression = null)
        {
            var diaconato = await _diaconatoRepository.GetAllAsync(_mapper.Map<Expression<Func<Diaconato, bool>>>(expression));
            return _mapper.Map<IEnumerable<DiaconatoVm>>(diaconato);
        }

        public async Task<(IEnumerable<DiaconatoVm> lista, int count)> GetAllPaginationAsync(Expression<Func<DiaconatoVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Diaconato, bool>>>(filtragem);
            var (lista, count) = await _diaconatoRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<DiaconatoVm>>(lista), count);
        }

        public async Task<DiaconatoVm?> GetByIdAsync(Guid id)
        {
            var item = await _diaconatoRepository.GetByIdAsync(id);
            var vm = _mapper.Map<DiaconatoVm>(item);

            if (item != null && item.Ativo && item.DataInativacao == null)
            {
                DateTime inicio = item.DataReativacao ?? item.DataMinisterio ?? DateTime.Today;
                DateTime fim = DateTime.Today;

                int meses = ((fim.Year - inicio.Year) * 12) + (fim.Month - inicio.Month);
                if (fim.Day < inicio.Day)
                    meses--;

                vm.TempoAcumuladoEmMeses = item.TempoAcumuladoEmMeses + Math.Max(0, meses);
            }

            return vm;
        }


        public async Task InativarAsync(Guid diaconatoId)
        {
            await _diaconatoRepository.InativarAsync(diaconatoId);
        }

        public async Task ReativarAsync(Guid diaconatoId)
        {
            await _diaconatoRepository.ReativarAsync(diaconatoId);
        }

        public async Task UpdateAsync(DiaconatoVm vm)
        {
            var existente = await _diaconatoRepository.GetByIdAsync(vm.DiaconatoId);
            if (existente == null) return;

            var atualizado = _mapper.Map<Diaconato>(vm);

            atualizado.TempoAcumuladoEmMeses = existente.TempoAcumuladoEmMeses;
            atualizado.DataReativacao = existente.DataReativacao;
            atualizado.DataInativacao = existente.DataInativacao;
            atualizado.Ativo = existente.Ativo;

            await _diaconatoRepository.UpdateAsync(atualizado);
        }

    }
}
