using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Pracownicy
{
    public class DetailsModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public DetailsModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

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
    }
}
