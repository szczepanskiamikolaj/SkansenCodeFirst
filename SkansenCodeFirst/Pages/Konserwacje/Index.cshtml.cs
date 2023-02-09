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
    public class IndexModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public IndexModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        public IList<Konserwacja> Konserwacja { get;set; }

        public async Task OnGetAsync()
        {
            Konserwacja = await _context.CzynnosciKonserwacyjne
                .Include(k => k.Pracownik)
                .Include(k => k.Zabytek).ToListAsync();
        }
    }
}
