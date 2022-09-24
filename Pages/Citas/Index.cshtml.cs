using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiTalleres.Data;
using RapiTalleres.Models;

namespace RapiTalleres.Pages.Citas
{
    public class IndexModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public IndexModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

        public IList<Cita> Cita { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Citas != null)
            {
                Cita = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Servicio)
                .Include(c => c.Tecnico).ToListAsync();
            }
        }
    }
}
