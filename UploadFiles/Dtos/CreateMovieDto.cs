using System.ComponentModel.DataAnnotations;

namespace UploadFiles.Dtos
{
    public class CreateMovieDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile ImageUrl { get; set; }
    }
}
