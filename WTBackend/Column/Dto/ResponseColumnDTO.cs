using WTBackend.Activity.Dto;

namespace WTBackend.Column.Dto
{
    public class ResponseColumnDTO
    {
        public string Title { get; set; }
        public List<ResponseActivityDTO> Activities { get; set; }

    }
}
