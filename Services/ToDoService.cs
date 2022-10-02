using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Data.Models;
using TodoList.Models;

namespace TodoList.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoListDbContext data;

        public ToDoService(ToDoListDbContext data)
        {
            this.data = data;
        }

        public void Add(ToDoFormModel task)
        {
            var taskData = new ToDo
            {
                Id = task.Id,
                Description = task.Description,
                IsDone = task.IsDone,
                Priority = task.Priority,
                CreatedDate = task.CreatedDate,
                TargetDate = task.TargetDate,
                UserId = task.UserId
            };

            this.data.Todos.Add(taskData);
            this.data.SaveChanges();
        }

        public AllToDosQueryModel All()
        {
            var task = this.data.Todos.ToList();

            var totalTasks = task.Count();

            var tasks = task
                .OrderByDescending(t => t.Id)
                .Select(t => new ToDoFormModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    IsDone = t.IsDone,
                    Priority = t.Priority,
                    CreatedDate = t.CreatedDate,
                    TargetDate = t.TargetDate,
                })
                .ToList();

            return new AllToDosQueryModel
            {
                Tasks = tasks
            };
        }
    }
}
