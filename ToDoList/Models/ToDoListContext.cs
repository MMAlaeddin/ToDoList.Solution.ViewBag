using Microsoft.EntityFrameworkCore;
// this file.. allows us to interact with the database

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    
    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}