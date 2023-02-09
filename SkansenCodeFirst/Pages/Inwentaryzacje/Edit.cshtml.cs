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

namespace SkansenCodeFirst.Pages.Inwentaryzacje
{
    public class EditModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public EditModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inwentaryzacja Inwentaryzacja { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inwentaryzacja = await _context.Inwentaryzacje
                .Include(i => i.Pracownik)
                .Include(i => i.Zabytek).FirstOrDefaultAsync(m => m.InwentaryzacjaId == id);

            if (Inwentaryzacja == null)
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

            _context.Attach(Inwentaryzacja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InwentaryzacjaExists(Inwentaryzacja.InwentaryzacjaId))
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

        private bool InwentaryzacjaExists(int id)
        {
            return _context.Inwentaryzacje.Any(e => e.InwentaryzacjaId == id);
        }
    }
}
