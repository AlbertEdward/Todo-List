using TodoList.Models;

namespace TodoList.Services
{
    public class ToDoQueryServiceModel
    {
        public int TotalTasks { get; init; }

        public ICollection<ToDoFormModel> Tasks { get; init; }
    }
}
