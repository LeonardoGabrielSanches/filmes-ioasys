using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesIoasys.Domain.Services.Movies;
using MoviesIoasys.WebApi.ViewModels.Movies;

namespace MoviesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateMovie([FromServices] CreateMovieService createMovieService,
                                         [FromBody] CreateMovieViewModel createMovieViewModel)
        {
            var movie = createMovieService.CreateMovie(createMovieViewModel);

            if (!movie.IsValid)
                return BadRequest(movie.NotificationError);

            return Created("", (MovieViewModel)movie);
        }

        [HttpPost("vote")]
        [Authorize(Roles = "User")]
        public IActionResult Vote([FromServices] CreateVoteForMovieService createVoteForMovieService,
                                  [FromBody] CreateVoteForMovieViewModel createVoteForMovieViewModel)
        {
            var vote = createVoteForMovieService.CreateVoteForMovie(createVoteForMovieViewModel);

            if (!vote.IsValid)
                return BadRequest(vote.NotificationError);

            return Created("", (VoteViewModel)vote);
        }
    }
}
