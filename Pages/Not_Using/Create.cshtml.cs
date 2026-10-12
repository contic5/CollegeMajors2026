using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CollegeMajors2026.Data;
using CollegeMajors2026.Models;

namespace CollegeMajors2026.Pages.CollegeMajors
{
    public class CreateModel : PageModel
    {
        private readonly CollegeMajors2026.Data.CollegeMajors2026Context _context;

        public CreateModel(CollegeMajors2026.Data.CollegeMajors2026Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CollegeMajor CollegeMajor { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CollegeMajor.Add(CollegeMajor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
