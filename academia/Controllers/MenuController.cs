using academia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace academia.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var perfisUsuario = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            // Realiza a consulta com join entre AuthMenu e AuthSubMenu
            var menusComSubmenus = _context.AuthMenus
                .Where(m => perfisUsuario.Contains(m.id.ToString()))
                .GroupJoin(
                    _context.AuthSubMenus,
                    m => m.id,
                    sm => sm.id_menu,
                    (m, submenus) => new
                    {
                        id_menu = m.id,
                        legenda_menu = m.chr_legenda,
                        url_menu = m.chr_url,
                        submenus = submenus.Select(sm => new
                        {
                            sm.id,
                            sm.chr_legenda,
                            sm.chr_url
                        }).ToList()
                    })
                .ToList();

            // Formatando a resposta para ter a estrutura desejada
            var menusAgrupados = menusComSubmenus
                .Select(menu => new
                {
                    menu.id_menu,
                    legenda_menu = menu.legenda_menu,
                    url_menu = menu.url_menu,
                    submenus = menu.submenus.Select(sm => new
                    {
                        id_submenu = sm.id,
                        legenda_submenu = sm.chr_legenda,
                        url_submenu = sm.chr_url
                    }).ToList()
                })
                .OrderBy(menu => menu.id_menu) // Ordena pelo id_menu
                .ToList();

            return Ok(menusAgrupados);
        }
    }
}
