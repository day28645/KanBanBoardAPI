using KanBanAPI.Data;
using KanBanAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanBanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(string id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(User userDB)
        {
            var checkUser = _context.Users.FirstOrDefault(c => c.Id_Card == userDB.Id_Card);

            if (checkUser != null)
            {
                ModelState.AddModelError("Id_Card", "The Id Card is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var user = new User
            {
                Id_Card = userDB.Id_Card,
                passwords = userDB.passwords,
                firstname = userDB.firstname,
                lastname = userDB.lastname,
                email = userDB.email,
                phone = userDB.phone,
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

    }

}
