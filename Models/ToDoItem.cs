using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string Task { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
