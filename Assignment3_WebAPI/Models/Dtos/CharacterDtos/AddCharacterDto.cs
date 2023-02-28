using System.ComponentModel.DataAnnotations;

namespace Assignment3_WebAPI.Models.Dtos.CharacterDtos
{
    public class AddCharacterDto
    {
        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string? Alias { get; set; }
        public string Picture { get; set; }
    }
}
