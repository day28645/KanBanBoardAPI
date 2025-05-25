using Azure.Core;
using KanBanAPI.Data;
using KanBanAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KanBanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly DataContext _context;

        public BoardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetBoardsAll")]
        public async Task<ActionResult<IEnumerable<Board>>> GetBoardsAll()
        {
            return await _context.Boards.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetBoards(int id)
        {
            var board = _context.Boards.Find(id);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        [HttpPost("CreateBoard")]
        public IActionResult CreateBoard([FromBody] AddBoardRequest request)
        {
            var checkBoard = _context.Boards.FirstOrDefault(c => c.boardName == request.boardName);

            if (checkBoard != null)
            {
                ModelState.AddModelError("BoardName", "This Board's Name is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var board = new Board
            {
                boardName = request.boardName,
                createDateTime = DateTime.Now,
                Id_Card = request.Id_Card
            };

            _context.Boards.Add(board);
            _context.SaveChanges();

            return Ok(board);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBoard(int id, [FromBody] UpdateBoardRequest request)
        {
            var board = _context.Boards.Find(id);

            if (board == null)
            {
                return NotFound(new { message = "Board not found" });
            }

            board.boardName = request.boardName;

            var edit = new EditBoard
            {
                Board_Id = id,
                Id_Card = request.Id_Card,
                editDateTime = DateTime.Now
            };

            _context.EditBoards.Add(edit);
            _context.SaveChanges();

            return Ok(board);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBoard(int id)
        {
            var board = _context.Boards.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            _context.Boards.Remove(board);
            _context.SaveChanges();

            return Ok();
        }

    }
}
