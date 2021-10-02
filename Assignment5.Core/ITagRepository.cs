using System.Collections.Generic;

namespace Assignment5.Core
{
    public interface ITagRepository
    {
        (Response response, int taskId) Create(TagCreateDTO tag);
        IReadOnlyCollection<TagListDTO> Read();
        TagDTO Read(int tagId);
        Response Update(TagUpdateDTO tag);
        Response Delete(int tagId, bool force = false);
    }
}