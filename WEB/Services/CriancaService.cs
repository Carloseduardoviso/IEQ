using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class CriancaService : ICriancaService
    {
        private readonly ICriancaRepository _criancaRepository;
        private readonly IMapper _mapper;

        public CriancaService(ICriancaRepository criancaRepository, IMapper mapper)
        {
            _criancaRepository = criancaRepository;
            _mapper = mapper;
        }
    }
}
