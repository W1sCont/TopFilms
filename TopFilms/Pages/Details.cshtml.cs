using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TopFilms.Pages
{
    public class DetailsModel(IMovieServices movieServices) : PageModel
    {
        public MovieDTO? Movie { get; set; } = new();
        public async Task OnGet(int id)
        {
            var result = await movieServices.GetMovieByIdAsync(id);
            if (result != null)
            {
                Movie = result;
            }
            else
            {
                RedirectToPage("/Index");
            }
        }
    }
}
