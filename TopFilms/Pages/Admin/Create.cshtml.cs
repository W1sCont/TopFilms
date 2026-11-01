using BLL.DTO;
using BLL.Services;
using TopFilms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TopFilms.Pages.Admin
{
    public class CreateModel(IMovieServices movieServices, IWebHostEnvironment appEnvironment) : PageModel
    {
        [BindProperty]
        public ViewModel Movie { get; set; } = new ViewModel();
        public void OnGet()
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(1_000_000_000)]
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Поле: {state.Key} | Помилка: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            IFormFile? image = Movie.Poster;
            if (image == null || image.Length == 0)
            {
                ModelState.AddModelError("Movie.Poster", "Будь ласка, завантажте постер для фільму.");
                return Page();
            }

            var fileName = Path.GetFileName(image.FileName);
            var relativePath = $"{fileName}";
            var absolutePath = Path.Combine(appEnvironment.WebRootPath, "Posters", fileName);
            Directory.CreateDirectory(Path.Combine(appEnvironment.WebRootPath, "Posters"));

            await using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            MovieDTO modelDTO = new MovieDTO
            {
                Name = Movie.Name,
                Director = Movie.Director,
                Genre = Movie.Genre,
                YearOfRelease = Movie.YearOfRelease,
                Image = relativePath,
                Description = Movie.Description,
                Rating = Movie.Rating
            };

            await movieServices.AddMovieAsync(modelDTO);
            await movieServices.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}
