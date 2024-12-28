using academia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace academia.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenuController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var perfisUsuario = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
          
            var menus = _context.AuthMenus
                                .Where(m => perfisUsuario.Any(p => m.id.Equals(p)))
                                .ToList();
            return Ok(menus);
        }
    }
}
