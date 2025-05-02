using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VisitantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Visitantes.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] Visitante visitante)
        {
            _context.Visitantes.Add(visitante);
            _context.SaveChanges();
            return Created("", visitante);
        }
    }
}
