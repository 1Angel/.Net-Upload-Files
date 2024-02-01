using UploadFiles.Dtos;
using UploadFiles.Models;

namespace UploadFiles.Repositories
{
    public interface IMoviesRepository
    {
        Task<Movie> Get();
        Task<Movie> GetById(int id);
        void Save(CreateMovieDto createMovieDto);
    }
}
