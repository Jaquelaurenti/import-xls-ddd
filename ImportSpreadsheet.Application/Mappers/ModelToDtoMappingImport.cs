using AutoMapper;
using ImportSpreadsheet.Application.Dtos;
using ImportSpreadsheet.Domain.Entitys;

namespace ImportSpreadsheet.Application.Mappers
{
    public class ModelToDtoMappingImport : Profile
    {

        public ModelToDtoMappingImport()
        {
            ImportDtoMap();
        }

        private void ImportDtoMap()
        {
            CreateMap<Import, ImportDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Directory, opt => opt.MapFrom(x => x.Directory));
        }
    }
}
