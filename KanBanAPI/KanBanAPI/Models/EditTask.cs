using Azure;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanBanAPI.Models
{
    public class EditTask
    {
        [Key]
        public int editTaskId { get; set; }
        public DateTime editDateTime { get; set; }
        [ForeignKey("Users")]
        public string Id_Card { get; set; }
        [ForeignKey("KanbanTasks")]
        public int Task_Id { get; set; }
        public User Users { get; set; } = null!;
        public KanbanTask KanbanTasks { get; set; } = null!;
    }
}
