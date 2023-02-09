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
    public class DetailsModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DetailsModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

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
    }
}
