using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
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


        public MembroService(IMembroRepository membroRepository, IMapper mapper, ICasalRepository casalRepository, ICriancaRepository criancaRepository, IDancaRepository dancaRepository, IDiaconatoRepository diaconatoRepository, IHomensRepository homensRepository)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
            _casalRepository = casalRepository;
            _criancaRepository = criancaRepository;
            _dancaRepository = dancaRepository;
            _diaconatoRepository = diaconatoRepository;
            _homensRepository = homensRepository;
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
            Membro result = _mapper.Map<Membro>(vm);
            await _membroRepository.Update(result);

            if (vm.CargoLocal == CargoLocal.Casal)
            {
                var casal = new Casal();
                casal.CasalId = Guid.NewGuid();
                casal.NomeCompleto = vm.NomeCompleto;
                casal.IgrejaId = vm.IgrejaId;
                casal.RegiaoId = vm.RegiaoId;
                casal.PastorId = vm.PastorId;
                casal.SuperintendenteEstadualId = vm.SuperintendenteEstadualId;
                casal.SuperintendenteRegionalId = vm.SuperintendenteRegionalId;
                casal.Contato = vm.Contato;
                casal.DataNascimento = vm.DataNascimento;
                casal.DataMinisterio = DateTime.Now;
                casal.DataBatismo = vm.DataBatismo;
                casal.TempoAcumuladoEmMeses = vm.TempoAcumuladoEmMeses;
                casal.DataReativacao = vm.DataReativacao;
                casal.DataInativacao = vm.DataInativacao;
                casal.Estado = vm.Estado;
                casal.Cidade = vm.Cidade;
                casal.FotoUrl = vm.FotoUrl;
                casal.Ativo = true;
                casal.CargoLocal = vm.CargoLocal;
                await _casalRepository.AddAsync(casal);
            }

            if (vm.CargoLocal == CargoLocal.Danca)
            {
                var danca = new Danca();
                danca.DancaId = Guid.NewGuid();
                danca.NomeCompleto = vm.NomeCompleto;
                danca.IgrejaId = vm.IgrejaId;
                danca.RegiaoId = vm.RegiaoId;
                danca.PastorId = vm.PastorId;
                danca.SuperintendenteEstadualId = vm.SuperintendenteEstadualId;
                danca.SuperintendenteRegionalId = vm.SuperintendenteRegionalId;
                danca.Contato = vm.Contato;
                danca.DataNascimento = vm.DataNascimento;
                danca.DataMinisterio = DateTime.Now;
                danca.DataBatismo = vm.DataBatismo;
                danca.TempoAcumuladoEmMeses = vm.TempoAcumuladoEmMeses;
                danca.DataReativacao = vm.DataReativacao;
                danca.DataInativacao = vm.DataInativacao;
                danca.Estado = vm.Estado;
                danca.Cidade = vm.Cidade;
                danca.FotoUrl = vm.FotoUrl;
                danca.Ativo = true;
                danca.CargoLocal = vm.CargoLocal;
                await _dancaRepository.AddAsync(danca);
            }

            if (vm.CargoLocal == CargoLocal.Crianca)
            {

            }

            if (vm.CargoLocal == CargoLocal.Diacono && vm.CargoLocal == CargoLocal.Diaconisa && vm.CargoLocal == CargoLocal.Diretor && vm.CargoLocal == CargoLocal.Diretora)
            {

            }

            if (vm.CargoLocal == CargoLocal.Homens)
            {

            }

            if (vm.CargoLocal == CargoLocal.JovemAdolescente)
            {

            }

            if (vm.CargoLocal == CargoLocal.Louvor)
            {

            }


            if (vm.CargoLocal == CargoLocal.Midia)
            {

            }

            if (vm.CargoLocal == CargoLocal.Mulheres)
            {

            }

            if (vm.CargoLocal == CargoLocal.Pastor && vm.CargoLocal == CargoLocal.PastorAuxiliar)
            {

            }

            if (vm.CargoLocal == CargoLocal.Teatro)
            {

            }
        }
    }
}
