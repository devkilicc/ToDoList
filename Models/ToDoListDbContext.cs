using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

public class ToDoListDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }

    // Parametreli constructor
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
        : base(options)
    {
    }
}
