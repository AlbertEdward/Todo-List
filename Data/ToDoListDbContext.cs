using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Data.Models;

namespace TodoList.Data
{
    public class ToDoListDbContext : IdentityDbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<IdentityUser>()
               .HasMany<ToDo>()
               .WithOne()
               .HasForeignKey(t => t.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}