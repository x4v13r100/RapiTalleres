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
    public class DeleteModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public DeleteModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio != null)
            {
                Servicio = servicio;
                _context.Servicios.Remove(Servicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
