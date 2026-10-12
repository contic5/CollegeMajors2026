using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeMajors2026.Models;

namespace CollegeMajors2026.Pages.CollegeMajors
{
    public class IndexModel : PageModel
    {
        private readonly CollegeMajors2026.Data.CollegeMajors2026Context _context;

        public IndexModel(CollegeMajors2026.Data.CollegeMajors2026Context context)
        {
            _context = context;
        }

        public IList<CollegeMajor> CollegeMajor { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CollegeMajorGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.CollegeMajor
                                            orderby m.Genre
                                            select m.Genre;

            var collegeMajors = from m in _context.CollegeMajor
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                collegeMajors = collegeMajors.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CollegeMajorGenre))
            {
                collegeMajors = collegeMajors.Where(x => x.Genre == CollegeMajorGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            CollegeMajor = await collegeMajors.ToListAsync();
        }


    }
}
