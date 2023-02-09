using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Inwentaryzacje
{
    public class DeleteModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DeleteModel(MSZcw.Context.InstrukcjaDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inwentaryzacja = await _context.Inwentaryzacje.FindAsync(id);

            if (Inwentaryzacja != null)
            {
                _context.Inwentaryzacje.Remove(Inwentaryzacja);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
