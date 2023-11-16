using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Too long for a name!")]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        [Range(0, 200, ErrorMessage = "Make your best guess!")]
        public int Age { get; set; }
    }
}