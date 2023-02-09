using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Sprzedaze
{
    public class EditModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public EditModel(MSZcw.Context.InstrukcjaDbContext context)
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
           ViewData["PracownikId"] = new SelectList(_context.Pracownicy, "PracownikId", nameof(Pracownik.Nazwisko));
           ViewData["ProduktId"] = new SelectList(_context.Produkty, "ProduktId", nameof(Produkt.ProduktName));
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

            _context.Attach(Sprzedaz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprzedazExists(Sprzedaz.SprzedazId))
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

        private bool SprzedazExists(int id)
        {
            return _context.Sprzedaze.Any(e => e.SprzedazId == id);
        }
    }
}
