using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models.Dtos
{
    public class GetMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }

        // Relationships
        public int FranchiseId { get; set; }
        public List<string> Characters { get; set; }
    }
}
