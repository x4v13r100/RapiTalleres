using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiTalleres.Data;
using RapiTalleres.Models;

namespace RapiTalleres.Pages.Tecnicos
{
    public class DetailsModel : PageModel
    {
        private readonly RapiTalleres.Data.TallerContext _context;

        public DetailsModel(RapiTalleres.Data.TallerContext context)
        {
            _context = context;
        }

      public Tecnico Tecnico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos.FirstOrDefaultAsync(m => m.TecnicoID == id);
            if (tecnico == null)
            {
                return NotFound();
            }
            else 
            {
                Tecnico = tecnico;
            }
            return Page();
        }
    }
}
