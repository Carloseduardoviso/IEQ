using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class LouvorService : ILouvorService
    {
        private readonly ILouvorRepository _louvorRepository;
        private readonly IMapper _mapper;

        public LouvorService(ILouvorRepository louvorRepository, IMapper mapper)
        {
            _louvorRepository = louvorRepository;
            _mapper = mapper;
        }
    }
}
