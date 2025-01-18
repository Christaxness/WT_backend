namespace WTBackend.Activity.Models
{
    public class ActivityModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
    }
}
