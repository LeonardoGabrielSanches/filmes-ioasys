using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Services.Movies;
using MoviesIoasys.WebApi.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetMovies([FromServices] GetAllMoviesFillteredService getAllMoviesFillteredService,
                                       [FromQuery] int page = 0, int size = 5, string director = "", string title = "", string category = "", string actor = "")
        {
            var movies = getAllMoviesFillteredService.GetAllMoviesFiltered(page, size, director, title, category, actor);

            return Ok(movies.Select(movie => (MovieDetailsViewModel)movie));
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public IActionResult GetMovieDetails([FromServices] GetMovieDetailsService getMovieDetailsService,
                                             Guid id)
        {
            var movie = getMovieDetailsService.GetMovieDetails(id);

            if (!movie?.Exists() ?? true)
                return NoContent();

            return Ok((MovieDetailsViewModel)movie);
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

        [HttpPost("vote/{id:Guid}")]
        [Authorize(Roles = "User")]
        public IActionResult Vote([FromServices] CreateVoteForMovieService createVoteForMovieService,
                                  [FromBody] CreateVoteForMovieViewModel createVoteForMovieViewModel,
                                  Guid id)
        {
            var vote = createVoteForMovieService.CreateVoteForMovie(CreateVoteForMovieViewModel.GetCreateVoteForMovieDTO(createVoteForMovieViewModel, id));

            if (!vote.IsValid)
                return BadRequest(vote.NotificationError);

            return Created("", (VoteViewModel)vote);
        }
    }
}
