using Azure;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanBanAPI.Models
{
    public class EditBoard
    {
        [Key]
        public int editId { get; set; }
        public DateTime editDateTime { get; set; }
        [ForeignKey("Users")]
        public string Id_Card { get; set; }
        [ForeignKey("Board")]
        public int Board_Id { get; set; }
        public User Users { get; set; } = null!;
        public Board Boards { get; set; } = null!;
    }
}
