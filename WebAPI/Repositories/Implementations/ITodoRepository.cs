using WebAPI.Models;

namespace WebAPI.Repositories.Implementations
{
    public interface ITodoRepository
    {
        void Save(Todo todo);
        void Delete(int id);
        Todo? Find(int id);
        List<Todo> FindAll();
    }
}
