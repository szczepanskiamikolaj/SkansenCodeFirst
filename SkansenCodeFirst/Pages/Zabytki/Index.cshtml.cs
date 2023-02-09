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
    public class IndexModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public IndexModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        public IList<Zabytek> Zabytek { get;set; }

        public async Task OnGetAsync()
        {
            Zabytek = await _context.Zabytki.ToListAsync();
        }

    }
}
