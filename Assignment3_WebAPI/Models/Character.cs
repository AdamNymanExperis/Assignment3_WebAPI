using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(50)] 
        public string? Alias { get; set; }
        public string Picture { get; set; }

        // relationship
        public ICollection<Movie> Movies { get; set; }
    }
}
