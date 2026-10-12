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
    public class DetailsModel : PageModel
    {
        private readonly CollegeMajors2026.Data.CollegeMajors2026Context _context;

        public DetailsModel(CollegeMajors2026.Data.CollegeMajors2026Context context)
        {
            _context = context;
        }

        public CollegeMajor CollegeMajor { get; set; } = default!;
        // <snippet_1>
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
        // </snippet_1>
    }
}
