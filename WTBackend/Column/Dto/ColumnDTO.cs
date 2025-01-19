using WTBackend.Activity.Dto;

namespace WTBackend.Column.Dto
{
    public class ColumnDTO
    {
        public string Title { get; set; }
        public List<ResponseActivityDTO> Activities { get; set; }

    }
}
