using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class HomensService : IHomensService
    {
        private readonly IHomensRepository _homensRepository;
        private readonly IMapper _mapper;

        public HomensService(IHomensRepository homensRepository, IMapper mapper)
        {
            _homensRepository = homensRepository;
            _mapper = mapper;
        }
    }
}
