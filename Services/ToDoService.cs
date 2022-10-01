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
                Name = task.Name,
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

        public async Task<ToDoQueryServiceModel> AllAsync(string name)
        {
            var tasksQuery = this.data.Todos.AsQueryable();

            var totalTasks = await tasksQuery.CountAsync();

            var tasks = tasksQuery
                .OrderByDescending(t => t.Id)
                .Select(t => new ToDoFormModel
                {
                    Id = task.Id,
                    Description = task.Description,
                    IsDone = task.IsDone,
                    Priority = task.Priority,
                    CreatedDate = task.CreatedDate,
                    TargetDate = task.TargetDate,
                })
                .ToList();

            return new ToDoQueryServiceModel
            {
                Tasks = tasks,
                TotalTasks = totalTasks
            };
        }
    }
}
