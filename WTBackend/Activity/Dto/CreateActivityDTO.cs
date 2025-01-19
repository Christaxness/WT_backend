namespace WTBackend.Activity.Dto
{
    public class CreateActivityDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ColumnTitle { get; set; } //Fk
    }
}
