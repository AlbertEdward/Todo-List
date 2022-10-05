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

        public AllToDosQueryModel All(string userId)
        {
            var task = this.data.Todos.ToList();

            var totalTasks = task.Count();

            var tasks = task
                .Where(t => t.UserId == userId)
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

        public ToDoFormModel Delete(int id)
        {
            var task = data.Todos.FirstOrDefault(t => t.Id == id);

            data.Todos.Remove(task);

            data.SaveChanges();

            return new ToDoFormModel();
        }

        public bool Edit(int id, string description, bool isDone, Priority priority, DateTime targetDate)
        {
            var taskData = this.data.Todos.Find(id);

            if (taskData == null)
            {
                return false;
            }
            
            taskData.Description = description;
            taskData.IsDone = isDone;
            taskData.Priority = priority;
            taskData.TargetDate = targetDate;

            this.data.SaveChangesAsync();

            return true;
        }

        public ToDoFormModel Details(int id)
        => this.data
            .Todos
            .Where(t => t.Id == id)
            .Select(task => new ToDoFormModel
            {
                Id = task.Id,
                Description = task.Description,
                Priority = task.Priority,
                IsDone = task.IsDone,
                TargetDate = task.TargetDate
            })
            .FirstOrDefault();
    }
}
