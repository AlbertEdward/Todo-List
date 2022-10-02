using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data.Models;
using TodoList.Infrastructure;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService toDoService;

        public ToDoController(IToDoService tasks)
        {
            this.toDoService = tasks;
        }

        [Authorize]
        public IActionResult All()
        {
            var allTasks = this.toDoService.All();

            return View(allTasks);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new ToDoFormModel());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(ToDoFormModel task)
        {
            var userId = this.User.GetId();

            var taskData = new ToDoFormModel
            {
                Description = task.Description,
                IsDone = task.IsDone,
                Priority = task.Priority,
                CreatedDate = task.CreatedDate,
                TargetDate = task.TargetDate,
                UserId = userId
            };

            this.toDoService.Add(taskData);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            this.toDoService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var task = this.toDoService.Details(id);

            return View(new ToDoFormModel
            {
                Id = task.Id,
                Description = task.Description,
                Priority = task.Priority,
                IsDone = task.IsDone,
                TargetDate = task.TargetDate
            }); 
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, ToDoFormModel task)
        {
            var taskIsEdited = this.toDoService.Edit(
                id,
                task.Description,
                task.IsDone,
                task.Priority,
                task.TargetDate);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var task = this.toDoService.Details(id);

            return View(new ToDoFormModel
            {
                Id = id,
                Description = task.Description,
                Priority = task.Priority,
                IsDone = task.IsDone,
                TargetDate = task.TargetDate,
                CreatedDate = task.CreatedDate
            });
        }
    }
}
