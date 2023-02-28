using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models.Dtos.MovieDtos
{
    public class AddMovieDto
    {
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }

        // Relationships
        public int FranchiseId { get; set; }
    }
}
