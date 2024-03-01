using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public DeleteModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieModel MovieModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviemodel = await _context.MovieModel.FirstOrDefaultAsync(m => m.Id == id);

            if (moviemodel == null)
            {
                return NotFound();
            }
            else
            {
                MovieModel = moviemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviemodel = await _context.MovieModel.FindAsync(id);
            if (moviemodel != null)
            {
                MovieModel = moviemodel;
                _context.MovieModel.Remove(MovieModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
