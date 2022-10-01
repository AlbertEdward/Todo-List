using Microsoft.AspNetCore.Identity;

namespace TodoList.Data.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public string UserId { get; set; }
    }
}
