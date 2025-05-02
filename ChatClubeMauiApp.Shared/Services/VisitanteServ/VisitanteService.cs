using ChatClubeMauiApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClubeMauiApp.Shared.Services.VisitanteServ
{
    public class VisitanteService : IVisitanteService
    {
        private readonly AppDbContext _context;
        public VisitanteService(AppDbContext context) => _context = context;
        public Task<List<Visitante>> GetVisitantesAsync() => _context.Visitantes.ToListAsync();
    }

}
