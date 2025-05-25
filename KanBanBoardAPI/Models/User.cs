using System.ComponentModel.DataAnnotations;

namespace KanBanBoardAPI.Models
{
    public class User
    {
        [Key]
        public string Id_Card { get; set; }
        public string passwords { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
