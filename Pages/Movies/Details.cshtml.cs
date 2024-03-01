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
    public class DetailsModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public DetailsModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

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
    }
}
