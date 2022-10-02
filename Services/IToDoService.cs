using TodoList.Data.Models;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IToDoService
    {
        void Add(ToDoFormModel task);

        AllToDosQueryModel All();

        ToDoFormModel Delete(int id);

        bool Edit(int id, string description, bool isDone, Priority priority, DateTime targetDate);

        ToDoFormModel Details(int id);
    }
}
