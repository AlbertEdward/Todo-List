namespace TodoList.Models
{
    public class ToDoFormModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public string UserId { get; set; }
    }
}
