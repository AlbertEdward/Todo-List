using TodoList.Data.Models;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IToDoService
    {
        void Add(ToDoFormModel task);

        Task<ToDoQueryServiceModel> AllAsync(AllToDosQueryModel task);
    }
}
