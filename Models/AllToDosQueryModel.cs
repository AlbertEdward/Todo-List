using TodoList.Data.Models;

namespace TodoList.Models
{
    public class AllToDosQueryModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime TargetDate { get; set; }

        public string UserId { get; set; }

        public ICollection<ToDoFormModel> Tasks { get; set; }
    }
}
