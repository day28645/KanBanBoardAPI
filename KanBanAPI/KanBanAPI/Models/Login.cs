using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace KanBanAPI.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }    
        [Required]
        public DateTime loginDateTime { get; set; }
        [Required]
        [ForeignKey("Users")]
        public string Id_Card { get; set; }
        public User Users { get; set; } = null!;
    }
}
