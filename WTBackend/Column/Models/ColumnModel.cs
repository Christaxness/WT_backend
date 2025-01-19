using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WTBackend.Activity.Models;

namespace WTBackend.Column.Models
{
    public class ColumnModel
    {
        [Key]
        public required string Title { get; set; }
        public List<ActivityModel> Activity { get; set; }
    }
}
