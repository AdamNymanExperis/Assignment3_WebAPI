using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
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
        public Franchise Franchise { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
