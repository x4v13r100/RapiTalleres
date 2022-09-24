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
    public class DeleteModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public DeleteModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cita Cita { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FirstOrDefaultAsync(m => m.CitaID == id);

            if (cita == null)
            {
                return NotFound();
            }
            else 
            {
                Cita = cita;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }
            var cita = await _context.Citas.FindAsync(id);

            if (cita != null)
            {
                Cita = cita;
                _context.Citas.Remove(Cita);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
