using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL.DTO;
using BLL.Services;

namespace TopFilms.Pages
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
