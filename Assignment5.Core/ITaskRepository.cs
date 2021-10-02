using System.Collections.Generic;

namespace Assignment5.Core
{
    public interface ITaskRepository
    {
        (Response response, int createdId) Create(TaskCreateDTO task);
        IReadOnlyCollection<TaskListDTO> Read(bool includeRemoved = false);
        TaskDetailsDTO Read(int taskId);
        Response Update(TaskUpdateDTO task);
        Response Delete(int taskId);
    }
}
