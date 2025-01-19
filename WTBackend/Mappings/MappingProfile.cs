using AutoMapper;
using WTBackend.Activity.Dto;
using WTBackend.Activity.Models;
using WTBackend.Column.Dto;
using WTBackend.Column.Models;

namespace WTBackend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActivityModel, ActivityDTO>();
            // Optional: Mapping von ColumnModel zu ColumnDto (mit Activities als DTOs)

            CreateMap<ColumnModel, ColumnDTO>()
                .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activity));
        }
    }
}
