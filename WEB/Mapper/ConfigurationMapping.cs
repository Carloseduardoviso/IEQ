using AutoMapper;
using WEB.Models.Entities;
using WEB.Models.ViewModels;

namespace WEB.Mapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Diaconato, DiaconatoVm>().ReverseMap().PreserveReferences();
            CreateMap<Pastores, PastoresVm>().ReverseMap().PreserveReferences();
            CreateMap<Regiao, RegiaoVm>().ReverseMap().PreserveReferences();
            CreateMap<Igreja, IgrejaVm>().ReverseMap().PreserveReferences();
            CreateMap<SuperintendenteEstadual, SuperintendenteEstadualVm>().ReverseMap().PreserveReferences();
            CreateMap<SuperintendenteRegional, SuperintendenteRegionalVm>().ReverseMap().PreserveReferences();
            CreateMap<SuperintendenteRegional, SuperintendenteRegionalVm>().ReverseMap().PreserveReferences();
            CreateMap<Membro, MembroVm>().ReverseMap().PreserveReferences();
            CreateMap<Usuario, UsuarioVm>().ReverseMap().PreserveReferences();
        }
    }
}
