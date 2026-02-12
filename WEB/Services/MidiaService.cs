using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class MidiaService : IMidiaService
    {
        private readonly IMidiaRepository _midiaRepository;
        private readonly IMapper _mapper;

        public MidiaService(IMidiaRepository midiaRepository, IMapper mapper)
        {
            _midiaRepository = midiaRepository;
            _mapper = mapper;
        }
    }
}
