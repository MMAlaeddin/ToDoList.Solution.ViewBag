using Microsoft.EntityFrameworkCore;
// this file.. allows us to interact with the database

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext // db represents an instance of this class (DbClass)
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; } //represents Items table in out to_do_list database
    
    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
} //eat burrito