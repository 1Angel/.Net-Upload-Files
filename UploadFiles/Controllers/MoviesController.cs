using Microsoft.AspNetCore.Mvc;
using UploadFiles.Dtos;
using UploadFiles.Repositories;

namespace UploadFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController: ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [HttpPost("create")]
        public ActionResult Create([FromForm] CreateMovieDto createMovieDto)
        {
            _moviesRepository.Save(createMovieDto);
            return Ok();
        }
    }
}
