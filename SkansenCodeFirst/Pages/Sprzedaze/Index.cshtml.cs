using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Sprzedaze
{
    public class IndexModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public IndexModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        public IList<Sprzedaz> Sprzedaz { get;set; }

        public async Task OnGetAsync()
        {
            Sprzedaz = await _context.Sprzedaze
                .Include(s => s.Pracownik)
                .Include(s => s.Produkt).ToListAsync();
        }
    }
}
