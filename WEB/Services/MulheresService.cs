using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class MulheresService : IMulheresService
    {
        private readonly IMulheresRepository _mulheresRepository;
        private readonly IMapper _mapper;

        public MulheresService(IMulheresRepository mulheresRepository, IMapper mapper)
        {
            _mulheresRepository = mulheresRepository;
            _mapper = mapper;
        }
    }
}
