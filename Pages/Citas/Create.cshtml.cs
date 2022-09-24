using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTalleres.Data;
using RapiTalleres.Models;

namespace RapiTalleres.Pages.Citas
{
    public class CreateModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public CreateModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteID"] = new SelectList(_context.Clientes, "ID", "Apellido");
        ViewData["ServicioID"] = new SelectList(_context.Servicios, "ServicioID", "Tipo");
        ViewData["TecnicoID"] = new SelectList(_context.Tecnicos, "TecnicoID", "Apellido");
            return Page();
        }

        [BindProperty]
        public Cita Cita { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Citas.Add(Cita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
