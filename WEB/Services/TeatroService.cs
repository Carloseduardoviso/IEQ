using AutoMapper;
using WEB.Data.Repositories.Interfaces;
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
    }
}