using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeMajors2026.Data;
using CollegeMajors2026.Models;

namespace CollegeMajors2026.Pages.CollegeMajors
{
    public class EditModel : PageModel
    {
        private readonly CollegeMajors2026.Data.CollegeMajors2026Context _context;

        public EditModel(CollegeMajors2026.Data.CollegeMajors2026Context context)
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

            var collegeMajor =  await _context.CollegeMajor.FirstOrDefaultAsync(m => m.Id == id);
            if (collegeMajor == null)
            {
                return NotFound();
            }
            CollegeMajor = collegeMajor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CollegeMajor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeMajorExists(CollegeMajor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CollegeMajorExists(int id)
        {
            return _context.CollegeMajor.Any(e => e.Id == id);
        }
    }
}
