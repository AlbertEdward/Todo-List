using TodoList.Models;

namespace TodoList.Services
{
    public interface IToDoService
    {
        void Add(ToDoFormModel task);

        AllToDosQueryModel All();
    }
}
