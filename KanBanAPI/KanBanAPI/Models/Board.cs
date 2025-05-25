using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace KanBanAPI.Models
{
    public class Board
    {
        [Key]
        public int Board_Id { get; set; }
        [MaxLength(20)]
        public string boardName { get; set; }
        public DateTime createDateTime { get; set; }
        [ForeignKey("Users")]
        public string Id_Card { get; set; }
        public User Users { get; set; } = null!;
        public List<EditBoard> EditBoards { get; } = [];
    }
}
