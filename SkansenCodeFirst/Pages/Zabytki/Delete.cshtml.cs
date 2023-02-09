using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Zabytki
{
    public class DeleteModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DeleteModel(MSZcw.Context.InstrukcjaDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zabytek = await _context.Zabytki.FindAsync(id);

            if (Zabytek != null)
            {
                _context.Zabytki.Remove(Zabytek);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
