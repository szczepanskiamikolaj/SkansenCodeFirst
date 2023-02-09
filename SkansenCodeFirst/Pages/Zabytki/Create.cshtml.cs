using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Zabytki
{
    public class CreateModel : PageModel
    {
        private readonly MSZcw.Context.InstrukcjaDbContext _context;

        public CreateModel(MSZcw.Context.InstrukcjaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zabytek Zabytek { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Zabytki.Add(Zabytek);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
