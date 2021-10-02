using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment5.Core
{
    public class TaskCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int? AssignedToId { get; set; }

        public string Description { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}