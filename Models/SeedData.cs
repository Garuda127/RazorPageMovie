using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (
                var context = new RazorPageMovieContext(
                    serviceProvider.GetRequiredService<DbContextOptions<RazorPageMovieContext>>()
                )
            )
            {
                if (context == null || context.MovieModel == null)
                {
                    throw new ArgumentNullException("Null RazorPageMovieContext");
                }
                // para mirar cualquier película
                if (context.MovieModel.Any())
                {
                    return; // DB muestra todo los que contiene la clase
                }

                context.MovieModel.AddRange(
                    new MovieModel
                    {
                        Title = "when Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99m,
                        Rating = "R"
                    },
                    new MovieModel
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99m,
                        Rating = "G"
                    },
                    new MovieModel
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 9.99m,
                        Rating = "G"
                    },
                    new MovieModel
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99m,
                        Rating = "NA"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
