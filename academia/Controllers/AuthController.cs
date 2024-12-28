using academia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using academia.Services;
using academia.Models;
using academia.DTOs;

namespace academia.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthUsuarioDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.AuthUsuarios
                .Include(u => u.AuthPerfilUsuarios)
                .FirstOrDefaultAsync(u => u.chr_login == request.chr_login);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.chr_senha, user.chr_senha_hash))
                return Unauthorized(new { message = "Login ou senha inválidos" });

            var roles = user.AuthPerfilUsuarios.Select(perfil => perfil.id_perfil).ToList();


            var token = _jwtService.GenerateToken(user.id.ToString(), user.chr_login, roles);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthUsuarioDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.AuthUsuarios.AnyAsync(u => u.chr_login == request.chr_login))
                return Conflict(new { message = "Login já está em uso." });

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.chr_senha);

            var usuario = new AuthUsuario
            {
                chr_login = request.chr_login,
                chr_senha_hash = passwordHash
            };

            _context.AuthUsuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuário registrado com sucesso." });
        }
    }
}



