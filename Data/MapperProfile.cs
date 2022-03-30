using AutoMapper;
using LMSGrupp3.Models.Entities;
using LMSGrupp3.Models.ViewModels;


namespace LexiconLMS.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ModuleActivityCreateViewModel, Module>();

        }

    }
}
