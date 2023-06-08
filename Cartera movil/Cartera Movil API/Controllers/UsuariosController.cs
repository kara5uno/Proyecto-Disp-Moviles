using Cartera_movil_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Xamarin.Essentials.Permissions;

namespace Cartera_movil_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var response = await _context.Usuarios.ToListAsync();
            if (response == null)
                return NotFound();
            else
                return response;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        [HttpDelete]
        public async Task<ActionResult<Usuario>> Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> Put(Usuario usuario)
        {
            foreach (var item in _context.Usuarios.Where(x => x.Id == usuario.Id))
            {
                item.Username = usuario.Username;
                item.Password = usuario.Password;
            }
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
