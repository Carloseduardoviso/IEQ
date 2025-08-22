using AutoMapper;
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

        public async Task<DiaconatoVm?> GetByIdAsync(Guid diaconatoId)
        {
            return _mapper.Map<DiaconatoVm>(await _diaconatoRepository.GetByIdAsync(diaconatoId));
        }

        public async Task UpdateAsync(DiaconatoVm diaconatoVm)
        {
            Diaconato diaconato = _mapper.Map<Diaconato>(diaconatoVm);
            await _diaconatoRepository.UpdateAsync(diaconato);
        }
    }
}
