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

namespace SkansenCodeFirst.Pages.Konserwacje
{
    public class EditModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public EditModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Konserwacja Konserwacja { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Konserwacja = await _context.CzynnosciKonserwacyjne
                .Include(k => k.Pracownik)
                .Include(k => k.Zabytek).FirstOrDefaultAsync(m => m.KonserwacjaId == id);

            if (Konserwacja == null)
            {
                return NotFound();
            }
           ViewData["PracownikId"] = new SelectList(_context.Pracownicy, "PracownikId", "PracownikId");
           ViewData["ZabytekId"] = new SelectList(_context.Zabytki, "ZabytekId", "ZabytekId");
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

            _context.Attach(Konserwacja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonserwacjaExists(Konserwacja.KonserwacjaId))
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

        private bool KonserwacjaExists(int id)
        {
            return _context.CzynnosciKonserwacyjne.Any(e => e.KonserwacjaId == id);
        }
    }
}
