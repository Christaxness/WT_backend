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
            // Mapping von ActivityModel zu ResponseActivityDTO für Antworten auf GET Requests
            CreateMap<ActivityModel, ResponseActivityDTO>();

            // Mapping von CreateActivityDTO zu ActivityModel für die Speicherung in der Datenbank
            CreateMap<CreateActivityDTO, ActivityModel>();


            // Mapping von ColumnModel zu ColumnDto (mit Activities als DTOs) um Loops zu verhindern
            CreateMap<ColumnModel, ResponseColumnDTO>()
                .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activity));

            // Mapping von CreateColumnDTO zu ColumnModel für die Speicherung in der Datenbank
            CreateMap<CreateColumnDTO,ColumnModel>();
        }
    }
}
