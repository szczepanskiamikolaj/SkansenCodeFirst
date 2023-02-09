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
    public class DeleteModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DeleteModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sprzedaz = await _context.Sprzedaze.FindAsync(id);

            if (Sprzedaz != null)
            {
                _context.Sprzedaze.Remove(Sprzedaz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
