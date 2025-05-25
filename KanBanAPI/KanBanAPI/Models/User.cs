using Azure;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace KanBanAPI.Models
{
    public class User
    {
        [Key]
        public string Id_Card { get; set; }
        [Required]
        [MaxLength(20)]
        public string passwords { get; set; }
        [Required]
        [MaxLength(20)]
        public string firstname { get; set; }
        [Required]
        [MaxLength(20)]
        public string lastname { get; set; }
        [Required]
        [MaxLength(20)]
        public string email { get; set; }
        [Required]
        [MaxLength(10)]
        public string phone { get; set; }
        public ICollection<Login> Logins { get; } = new List<Login>();
        public ICollection<Board> createBoards { get; } = new List<Board>();
        public ICollection<KanbanTask> createTasks { get; } = new List<KanbanTask>();
        public List<EditBoard> EditBoards { get; } = [];
        public List<Board> Boards { get; } = [];
        public List<EditTask> EditTasks { get; } = [];
        public List<KanbanTask> KanbanTasks { get; } = [];
    }
}
