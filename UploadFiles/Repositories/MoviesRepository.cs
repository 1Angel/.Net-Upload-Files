using UploadFiles.Data;
using UploadFiles.Dtos;
using UploadFiles.Models;

namespace UploadFiles.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public MoviesRepository(IWebHostEnvironment environment, AppDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public Task<Movie> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async void Save(CreateMovieDto createMovieDto)
        {
            var folder = Path.Combine(_environment.ContentRootPath, "images");
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var imageName = $"{Guid.NewGuid()}-{createMovieDto.ImageUrl.FileName}";
            var ImagePath = Path.Combine(folder, imageName);

            using(FileStream stream = new FileStream(ImagePath, FileMode.Create))
            {
                stream.CopyToAsync(stream);
            }

            var movie = new Movie
            {
                Title = createMovieDto.Title,
                Description = createMovieDto.Description,
                ImageUrl = ImagePath
            };

            var create = _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
    }
}
