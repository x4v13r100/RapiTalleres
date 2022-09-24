using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiTalleres.Data;
using RapiTalleres.Models;

namespace RapiTalleres.Pages.Servicios
{
    public class IndexModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public IndexModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

        public IList<Servicio> Servicio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Servicios != null)
            {
                Servicio = await _context.Servicios.ToListAsync();
            }
        }
        
    }
}
