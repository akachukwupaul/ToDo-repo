using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    public class ToDoContext: DbContext
    {
        // Constructor: accepts options (like connection string, provider, etc.) and passes them to the base DbContext class
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data for Category table
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "work", Name = "Work"},
                new Category { CategoryId = "ex", Name = "Exercise" },
                new Category { CategoryId = "home", Name = "Home" },
                new Category { CategoryId = "shop", Name = "shop" }
              );
            // Seed initial data for Status table
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "closed", Name = "Completed" }
                );
            // Call base class implementation (optional, but good practice)
            base.OnModelCreating(modelBuilder);
        }
    }
}
