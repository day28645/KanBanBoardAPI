using KanBanAPI.Data;
using KanBanAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KanBanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("CreateLogin")]
        public IActionResult CreateLogin([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id_Card == request.Id_Card && u.passwords == request.passwords);

            if (user == null)
            {
                return NotFound(new { message = "Invalid ID card or password" });
            }

            var login = new Models.Login
            {
                Id_Card = request.Id_Card,
                loginDateTime = DateTime.Now,
            };

            _context.Logins.Add(login);
            _context.SaveChanges();

            return Ok();
        }
    }
}
