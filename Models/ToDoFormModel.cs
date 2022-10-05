using System.ComponentModel.DataAnnotations;
using TodoList.Data.Models;

namespace TodoList.Models
{
    public class ToDoFormModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime TargetDate { get; set; } = DateTime.Now;

        public string UserId { get; set; }
    }
}
