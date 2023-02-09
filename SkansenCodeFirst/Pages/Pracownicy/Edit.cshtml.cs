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

namespace SkansenCodeFirst.Pages.Pracownicy
{
    public class EditModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public EditModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pracownik Pracownik { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pracownik = await _context.Pracownicy.FirstOrDefaultAsync(m => m.PracownikId == id);

            if (Pracownik == null)
            {
                return NotFound();
            }
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

            _context.Attach(Pracownik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownikExists(Pracownik.PracownikId))
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

        private bool PracownikExists(int id)
        {
            return _context.Pracownicy.Any(e => e.PracownikId == id);
        }
    }
}
