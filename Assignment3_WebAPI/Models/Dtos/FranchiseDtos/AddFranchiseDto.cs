using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models.Dtos.FranchiseDtos
{
    public class AddFranchiseDto
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
