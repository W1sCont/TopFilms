using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopFilms.Models;

namespace TopFilms.Pages.Admin
{
    public class DeleteModel(IMovieServices movieServices) : PageModel
    {
        [BindProperty]
        public ViewModel Movie { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var movieDto = await movieServices.GetMovieByIdAsync(id);
            if (movieDto == null)
            {
                return NotFound(); 
            }
            Movie = new ViewModel
            {
                Id = movieDto.Id, 
                Name = movieDto.Name,
                Director = movieDto.Director,
                Genre = movieDto.Genre,
                YearOfRelease = movieDto.YearOfRelease,
                Description = movieDto.Description,
                Rating = movieDto.Rating
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await movieServices.DeleteMovieAsync(id);
            await movieServices.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}