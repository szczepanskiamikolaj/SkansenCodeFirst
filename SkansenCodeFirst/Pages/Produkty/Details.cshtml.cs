using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Produkty
{
    public class DetailsModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DetailsModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        public Produkt Produkt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produkt = await _context.Produkty.FirstOrDefaultAsync(m => m.ProduktId == id);

            if (Produkt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
