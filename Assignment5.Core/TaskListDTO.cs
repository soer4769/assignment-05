using System.Collections.Generic;

namespace Assignment5.Core
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? AssignedToId { get; set; }

        public string AssignedToName { get; set; }

        public State State { get; set; }

        public ICollection<KeyValuePair<int, string>> Tags { get; set; }
    }
}