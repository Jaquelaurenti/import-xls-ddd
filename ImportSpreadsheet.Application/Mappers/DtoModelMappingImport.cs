using AutoMapper;
using ImportSpreadsheet.Application.Dtos;
using ImportSpreadsheet.Domain.Entitys;

namespace ImportSpreadsheet.Application.Mappers
{
    public class DtoToModelMappingImport : Profile
    {
        public DtoToModelMappingImport()
        {
            ImportDto();
        }

        private void ImportDto()
        {
            CreateMap<ImportDTO, Import>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Directory, opt => opt.MapFrom(x => x.Directory));
        }
    }
}
