using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace KanBanAPI.Models
{
    public class KanbanTask
    {
        [Key]
        public int Task_Id { get; set; }
        [MaxLength(20)]
        public string taskName { get; set; }
        public DateTime createDateTime { get; set; }
        [ForeignKey("Users")]
        public string Id_Card { get; set; }
        public List<EditTask> EditTasks { get; } = [];
        public User Users { get; set; } = null!;
    }
}
