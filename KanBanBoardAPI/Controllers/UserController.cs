using KanBanBoardAPI.Data;
using KanBanBoardAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanBanBoardAPI.Controllers
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
        public List<User> GetUsers() 
        {
            return _context.Users.OrderByDescending(c => c.Id_Card).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(string id) 
        { 
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
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

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id,User userDB)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.passwords = userDB.passwords ?? "";
            user.firstname = userDB.firstname ?? "";
            user.lastname = userDB.lastname ?? "";
            user.email = userDB.email ?? "";
            user.phone = userDB.phone;

            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
      
            return Ok();
        }

    }
}
