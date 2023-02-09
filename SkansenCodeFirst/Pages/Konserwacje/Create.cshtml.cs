using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSZcw.Context;
using SkansenCodeFirst.Model;

namespace SkansenCodeFirst.Pages.Konserwacje
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
        ViewData["PracownikId"] = new SelectList(_context.Pracownicy, "PracownikId", nameof(Pracownik.Nazwisko));
        ViewData["ZabytekId"] = new SelectList(_context.Zabytki, "ZabytekId", nameof(Zabytek.ZabytekNazwa));
            return Page();
        }

        [BindProperty]
        public Konserwacja Konserwacja { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CzynnosciKonserwacyjne.Add(Konserwacja);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
