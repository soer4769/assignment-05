using System.ComponentModel.DataAnnotations;

namespace Assignment5.Core
{
    public class TagCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}