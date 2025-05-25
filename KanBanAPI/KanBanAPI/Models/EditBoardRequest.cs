using System.ComponentModel.DataAnnotations.Schema;

namespace KanBanAPI.Models
{
    public class EditBoardRequest
    {
        public int Board_Id { get; set; }
        public string Id_Card { get; set; }
    }
}
