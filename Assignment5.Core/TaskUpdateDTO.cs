namespace Assignment5.Core
{
    public class TaskUpdateDTO : TaskCreateDTO
    {
        public int Id { get; set; }

        public State State { get; set; }
    }
}