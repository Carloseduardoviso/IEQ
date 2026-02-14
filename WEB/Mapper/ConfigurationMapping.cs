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
            CreateMap<Crianca, CriancaVm>().ReverseMap().PreserveReferences();
            CreateMap<Homens, HomensVm>().ReverseMap().PreserveReferences();
            CreateMap<JovemAdolescente, JovemAdolescenteVm>().ReverseMap().PreserveReferences();
            CreateMap<Louvor, LouvorVm>().ReverseMap().PreserveReferences();
            CreateMap<Midia, MidiaVm>().ReverseMap().PreserveReferences();
            CreateMap<Mulheres, MulheresVm>().ReverseMap().PreserveReferences();
            CreateMap<Teatro, TeatroVm>().ReverseMap().PreserveReferences();
            CreateMap<Danca, DancaVm>().ReverseMap().PreserveReferences();
        }
    }
}