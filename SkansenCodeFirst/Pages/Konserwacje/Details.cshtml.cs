using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Konserwacje
{
    public class DetailsModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DetailsModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
