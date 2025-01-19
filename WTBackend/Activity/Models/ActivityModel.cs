using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WTBackend.Column.Models;

namespace WTBackend.Activity.Models
{
    public class ActivityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        [ForeignKey("ColumnTitle")]
        public string ColumnTitle { get; set; }
        public ColumnModel Column { get; set; }
    }
}
