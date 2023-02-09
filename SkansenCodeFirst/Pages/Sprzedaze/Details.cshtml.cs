using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Sprzedaze
{
    public class DetailsModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DetailsModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        public Sprzedaz Sprzedaz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sprzedaz = await _context.Sprzedaze
                .Include(s => s.Pracownik)
                .Include(s => s.Produkt).FirstOrDefaultAsync(m => m.SprzedazId == id);

            if (Sprzedaz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
