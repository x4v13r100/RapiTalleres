using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapiTalleres.Data;
using RapiTalleres.Models;

namespace RapiTalleres.Pages.Citas
{
    public class EditModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public EditModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita =  await _context.Citas.FirstOrDefaultAsync(m => m.CitaID == id);
            if (cita == null)
            {
                return NotFound();
            }
            Cita = cita;
           ViewData["ClienteID"] = new SelectList(_context.Clientes, "ID", "Apellido");
           ViewData["ServicioID"] = new SelectList(_context.Servicios, "ServicioID", "Tipo");
           ViewData["TecnicoID"] = new SelectList(_context.Tecnicos, "TecnicoID", "Apellido");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(Cita.CitaID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CitaExists(int id)
        {
          return _context.Citas.Any(e => e.CitaID == id);
        }
    }
}
