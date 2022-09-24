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
    public class DetailsModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public DetailsModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

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
    }
}
