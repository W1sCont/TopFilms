using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopFilms.Models;

namespace TopFilms.Pages.Admin
{
    public class EditModel(IMovieServices movieServices, IWebHostEnvironment appEnvironment) : PageModel
    {
        [BindProperty]
        public ViewModel Movie { get; set; } = new();
        public async Task<IActionResult> OnGet(int id)
        {
            var result = await movieServices.GetMovieByIdAsync(id);
            if (result == null) return NotFound();

            Movie = new ViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Director = result.Director,
                Genre = result.Genre,
                YearOfRelease = result.YearOfRelease,
                Description = result.Description,
                Rating = result.Rating
            };

            return Page();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            var existingMovie = await movieServices.GetMovieByIdAsync(Movie.Id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string relativePath = existingMovie.Image;

            if (Movie.Poster != null && Movie.Poster.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Movie.Poster.FileName);
                relativePath = fileName;
                var absolutePath = Path.Combine(appEnvironment.WebRootPath, "Posters", fileName);

                Directory.CreateDirectory(Path.Combine(appEnvironment.WebRootPath, "Posters"));

                using (var fileStream = new FileStream(absolutePath, FileMode.Create))
                {
                    await Movie.Poster.CopyToAsync(fileStream);
                }
            }

            MovieDTO modelDTO = new MovieDTO
            {
                Id = Movie.Id,
                Name = Movie.Name,
                Director = Movie.Director,
                Genre = Movie.Genre,
                YearOfRelease = Movie.YearOfRelease,
                Image = relativePath, 
                Description = Movie.Description,
                Rating = Movie.Rating
            };

            await movieServices.EditMovieAsync(modelDTO);
            await movieServices.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}
