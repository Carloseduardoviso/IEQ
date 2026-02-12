using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class JovemAdolescenteService : IJovemAdolescenteService
    {
        private readonly IJovemAdolescenteRepository _repository;
        private readonly IMapper _mapper;

        public JovemAdolescenteService(IJovemAdolescenteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
