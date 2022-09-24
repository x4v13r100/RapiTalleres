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
    public class DetailsModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public DetailsModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

      public Servicio Servicio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FirstOrDefaultAsync(m => m.ServicioID == id);
            if (servicio == null)
            {
                return NotFound();
            }
            else 
            {
                Servicio = servicio;
            }
            return Page();
        }
    }
}
