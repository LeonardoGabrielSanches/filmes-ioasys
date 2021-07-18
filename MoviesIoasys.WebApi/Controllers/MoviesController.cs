using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Services.Movies;
using MoviesIoasys.WebApi.ViewModels.Movies;
using System;

namespace MoviesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet("{id:Guid}")]
        [Authorize]
        public IActionResult GetMovieDetails([FromServices] IMoviesRepository moviesRepository,
                                             Guid id)
        {
            var movie = moviesRepository.Get(id);

            if (!movie?.Exists() ?? true)
                return NoContent();

            return Ok((MovieViewModel)movie);
        }

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
