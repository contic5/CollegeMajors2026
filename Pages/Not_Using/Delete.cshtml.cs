using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollegeMajors2026.Data;
using CollegeMajors2026.Models;

namespace CollegeMajors2026.Pages.CollegeMajors
{
    public class DeleteModel : PageModel
    {
        private readonly CollegeMajors2026.Data.CollegeMajors2026Context _context;

        public DeleteModel(CollegeMajors2026.Data.CollegeMajors2026Context context)
        {
            _context = context;
        }

        [BindProperty]
        public CollegeMajor CollegeMajor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeMajor = await _context.CollegeMajor.FirstOrDefaultAsync(m => m.Id == id);

            if (collegeMajor == null)
            {
                return NotFound();
            }
            else
            {
                CollegeMajor = collegeMajor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeMajor = await _context.CollegeMajor.FindAsync(id);
            if (collegeMajor != null)
            {
                CollegeMajor = collegeMajor;
                _context.CollegeMajor.Remove(CollegeMajor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
