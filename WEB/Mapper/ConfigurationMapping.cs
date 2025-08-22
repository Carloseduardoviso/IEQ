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
        }
    }
}
