using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using BigWebBooksRazor_Temp.Models;

namespace BigWebBooksRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Боевик", DisplayOrder = 1 },
                new Category() { Id = 2, Name = "Ужасы", DisplayOrder = 2 },
                new Category() { Id = 3, Name = "Мистика", DisplayOrder = 3 },
                new Category() { Id = 4, Name = "Триллер", DisplayOrder = 4 },
                new Category() { Id = 5, Name = "Драма", DisplayOrder = 5 },
                new Category() { Id = 6, Name = "Комедия", DisplayOrder = 6 },
                new Category() { Id = 7, Name = "Фэнтензи", DisplayOrder = 7 },
                new Category() { Id = 8, Name = "Фантастика", DisplayOrder = 8 },
                new Category() { Id = 9, Name = "Нон-фикшн", DisplayOrder = 9 },
                new Category() { Id = 10, Name = "Научпоп", DisplayOrder = 10 });
        }
    }
}
