using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // Relationships
        public ICollection<Movie> Movies { get; set; }
    }
}
