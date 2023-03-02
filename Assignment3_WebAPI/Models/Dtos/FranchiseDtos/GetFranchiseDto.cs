using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models.Dtos.FranchiseDtos
{
    public class GetFranchiseDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // Relationships
        public List<string> Movies { get; set; }
    }
}
