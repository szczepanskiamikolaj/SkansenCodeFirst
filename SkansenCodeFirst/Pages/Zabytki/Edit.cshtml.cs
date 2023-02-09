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

namespace SkansenCodeFirst.Pages.Zabytki
{
    public class EditModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public EditModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zabytek Zabytek { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zabytek = await _context.Zabytki.FirstOrDefaultAsync(m => m.ZabytekId == id);

            if (Zabytek == null)
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

            _context.Attach(Zabytek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZabytekExists(Zabytek.ZabytekId))
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

        private bool ZabytekExists(int id)
        {
            return _context.Zabytki.Any(e => e.ZabytekId == id);
        }
    }
}
