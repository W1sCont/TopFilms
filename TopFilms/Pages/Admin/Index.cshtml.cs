using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TopFilms.Pages.Admin
{
    public class IndexModel(IMovieServices movieServices) : PageModel
    {
        public IEnumerable<MovieDTO> MovieColections { get; private set; } = Enumerable.Empty<MovieDTO>();
        public async Task OnGet()
        {
            MovieColections = await movieServices.GetAllMoviesAsync();
        }
    }
}
