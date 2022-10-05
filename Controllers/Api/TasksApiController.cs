using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoList.Infrastructure;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers.Api
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksApiController : ControllerBase
    {
        private readonly IToDoService toDoService;

        public TasksApiController(IToDoService tasks)
            => this.toDoService = tasks;

        
        [HttpGet]
        [Route("all")]
        public AllToDosQueryModel AllTasks()
        {
            var userId = User.GetId();

            return this.toDoService.All(userId);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public ToDoFormModel Delete(int id)
        {
            return this.toDoService.Delete(id);
        }
    }
}
