# Assignment #5

## C&#35;

Clone this repository and bring the code pieces you need into your BDSA Assignments GitHub repository.

### Kanban Board part deux

[![Simple-kanban-board-](https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Simple-kanban-board-.jpg/512px-Simple-kanban-board-.jpg)](https://commons.wikimedia.org/wiki/File:Simple-kanban-board-.jpg "Jeff.lasovski [CC BY-SA 3.0 (https://creativecommons.org/licenses/by-sa/3.0)], via Wikimedia Commons")

Implement and test the `ITaskRepository` and `ITagRepository` interfaces.

```csharp
public enum Response
{
    Created,
    Updated,
    Deleted,
    NotFound,
    BadRequest,
    Conflict
}

public interface ITaskRepository
{
    (Response response, int taskId) Create(TaskCreateDTO task);
    IReadOnlyCollection<TaskListDTO> Read(bool includeRemoved = false);
    TaskDetailsDTO Read(int taskId);
    Response Update(TaskUpdateDTO task);
    Response Delete(int taskId);
}

public interface ITagRepository
{
    (Response response, int taskId) Create(TagCreateDTO tag);
    ICollection<TagDTO> Read();
    TagDTO Read(int tagId);
    Response Update(TagUpdateDTO tag);
    Response Delete(int tagId, bool force = false);
}
```

with the following rules:

#### 1. General

1. Trying to update or delete a non-existing entity should return `NotFound`.
1. `CUD` should return a proper `Response`.
1. Your are not allowed to write `throw new ...` - use the `Response` instead.
1. Your code must use an in-memory database and/or mocks for testing.
1. If a task or tag is not found, return `null`.

#### 2. Task Repository

1. Only tasks which have the state `New` can be deleted from the database.
1. Deleting a task which is `Active` should set its state to `Removed`.
1. Deleting a task which is `Resolved`, `Closed`, or `Removed` should return `Conflict`.
1. Creating a task will set its state to `New`.
1. Create/update task must allow for editing tags.
1. Assigning a user which does not exist should return `Conflict`.
1. TaskRepository may *not* reference *TagRepository*.
1. Create/update should allow adding/removing a user - and return `BadRequest` if the user does not exist.

#### 3. Tag Repository

1. Tags which are in use may only be deleted using the `force`.
1. Trying to delete a tag in use without the `force` should return `Conflict`.
1. Trying to create a tag which exists already should return `Conflict`.
