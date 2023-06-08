using Cartera_movil.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartera_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarterasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarterasController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cartera>>> Get()
        {
            var response = await _context.Carteras.ToListAsync();
            if (response == null)
                return NotFound();
            else
                return response;
        }

        [HttpPost]
        public async Task<ActionResult<Cartera>> Post(Cartera cartera)
        {
            _context.Carteras.Add(cartera);
            await _context.SaveChangesAsync();
            return cartera;
        }

        [HttpDelete]
        public async Task<ActionResult<Cartera>> Delete(Cartera cartera)
        {
            _context.Carteras.Remove(cartera);
            await _context.SaveChangesAsync();
            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<Cartera>> Put(Cartera cartera)
        {
            foreach (var item in _context.Carteras.Where(x => x.Id == cartera.Id))
            {
                item.User = cartera.User;
                item.Name = cartera.Name;
                item.Dinero = cartera.Dinero;
            }
            await _context.SaveChangesAsync();
            return cartera;
        }
    }
}
