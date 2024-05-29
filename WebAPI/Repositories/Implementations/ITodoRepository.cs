using WebAPI.Models;

namespace WebAPI.Repositories.Implementations
{
    public interface ITodoRepository
    {
        void Save(Todo history);
        void Delete(Todo history);
        Todo Find(int id);
    }
}
