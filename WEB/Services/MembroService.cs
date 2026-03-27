using AutoMapper;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.Enuns;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class MembroService : IMembroService
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IMapper _mapper;

        private readonly ICasalRepository _casalRepository;
        private readonly ICriancaRepository _criancaRepository;
        private readonly IDancaRepository _dancaRepository;
        private readonly IDiaconatoRepository _diaconatoRepository;
        private readonly IHomensRepository _homensRepository;
        private readonly IJovemAdolescenteRepository _jovemAdolescenteRepository;
        private readonly ILouvorRepository _louvorRepository;
        private readonly IMidiaRepository _midiaRepository;
        private readonly IMulheresRepository _mulheresRepository;
        private readonly IPastoresRepository _pastoresRepository;
        private readonly ITeatroRepository _teatroRepository;


        public MembroService(IMembroRepository membroRepository, IMapper mapper, ICasalRepository casalRepository, ICriancaRepository criancaRepository, IDancaRepository dancaRepository, IDiaconatoRepository diaconatoRepository, IHomensRepository homensRepository, IJovemAdolescenteRepository jovemAdolescenteRepository, ILouvorRepository louvorRepository, IMidiaRepository midiaRepository, IMulheresRepository mulheresRepository, IPastoresRepository pastoresRepository, ITeatroRepository teatroRepository)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
            _casalRepository = casalRepository;
            _criancaRepository = criancaRepository;
            _dancaRepository = dancaRepository;
            _diaconatoRepository = diaconatoRepository;
            _homensRepository = homensRepository;
            _jovemAdolescenteRepository = jovemAdolescenteRepository;
            _louvorRepository = louvorRepository;
            _midiaRepository = midiaRepository;
            _mulheresRepository = mulheresRepository;
            _pastoresRepository = pastoresRepository;
            _teatroRepository = teatroRepository;
        }

        public async Task AddAsync(MembroVm vm)
        {
            var result = _mapper.Map<Membro>(vm);
            await _membroRepository.AddAsync(result);
        }

        public async Task<IEnumerable<MembroVm>> GetAllAsync(Expression<Func<MembroVm, bool>>? expression = null, params Expression<Func<MembroVm, object?>>[]? includes)
        {
            var result = await _membroRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Membro, bool>>>(expression),
             _mapper.Map<Expression<Func<Membro, object>>[]>(includes));
            return _mapper.Map<IEnumerable<MembroVm>>(result);
        }

        public async Task<(IEnumerable<MembroVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MembroVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Membro, bool>>>(filtragem);
            var (lista, count) = await _membroRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<MembroVm>>(lista), count);
        }

        public async Task<MembroVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MembroVm, bool>>? expression = null)
        {
            var result = await _membroRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Membro, bool>>>(expression));
            return _mapper.Map<MembroVm>(result);
        }

        public async Task<MembroVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<MembroVm>(await _membroRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _membroRepository.InativarAsync(id);
        }

        public async Task ReativarAsync(Guid id)
        {
            await _membroRepository.ReativarAsync(id);
        }

        public Task<MembroVm> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(MembroVm vm)
        {
            Membro membro = _mapper.Map<Membro>(vm);

            if (vm.CargoLocal == CargoLocal.Casal)
            {
                var casal = Casal.Adicionar(vm);
                casal.MembroId = vm.MembroId;
                await _casalRepository.AddAsync(casal);                              
            }

            if (vm.CargoLocal == CargoLocal.Danca)
            {
                var danca = Danca.Adicionar(vm);
                danca.MembroId = vm.MembroId;
                await _dancaRepository.AddAsync(danca);
            }

            if (vm.CargoLocal == CargoLocal.Crianca)
            {
                var crianca = Crianca.Adicionar(vm);
                crianca.MembroId = vm.MembroId;
                await _criancaRepository.AddAsync(crianca);
            }

            if (vm.CargoLocal == CargoLocal.Diacono || vm.CargoLocal == CargoLocal.Diaconisa || vm.CargoLocal == CargoLocal.Diretor || vm.CargoLocal == CargoLocal.Diretora)
            {
                var diaconato = Diaconato.Adicionar(vm);
                diaconato.MembroId = vm.MembroId;
                await _diaconatoRepository.AddAsync(diaconato);
            }

            if (vm.CargoLocal == CargoLocal.Homens)
            {
                var homens = Homens.Adicionar(vm);
                homens.MembroId = vm.MembroId;
                await _homensRepository.AddAsync(homens);
            }

            if (vm.CargoLocal == CargoLocal.JovemAdolescente)
            {
                var jovemAdolescente = JovemAdolescente.Adicionar(vm);
                jovemAdolescente.MembroId = vm.MembroId;
                await _jovemAdolescenteRepository.AddAsync(jovemAdolescente);
            }

            if (vm.CargoLocal == CargoLocal.Louvor)
            {
                var louvor = Louvor.Adicionar(vm);
                louvor.MembroId = vm.MembroId;
                await _louvorRepository.AddAsync(louvor);
            }

            if (vm.CargoLocal == CargoLocal.Midia)
            {
                var midia = Midia.Adicionar(vm);
                midia.MembroId = vm.MembroId;
                await _midiaRepository.AddAsync(midia);
            }

            if (vm.CargoLocal == CargoLocal.Mulheres)
            {
                var mulheres = Mulheres.Adicionar(vm);
                mulheres.MembroId = vm.MembroId;
                await _mulheresRepository.AddAsync(mulheres);
            }

            if (vm.CargoLocal == CargoLocal.Pastor || vm.CargoLocal == CargoLocal.PastorAuxiliar)
            {
                var pastor = Pastores.Adicionar(vm);
                pastor.MembroId = vm.MembroId;
                await _pastoresRepository.AddAsync(pastor);
            }

            if (vm.CargoLocal == CargoLocal.Teatro)
            {
                var teatro = Teatro.Adicionar(vm);
                teatro.MembroId = vm.MembroId;
                await _teatroRepository.AddAsync(teatro);
            }

            membro.CargoLocal = CargoLocal.Membro;
            await _membroRepository.Update(membro);
        }
    }
}