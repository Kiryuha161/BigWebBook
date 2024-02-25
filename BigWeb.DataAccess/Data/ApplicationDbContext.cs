using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BigWeb.Models;

namespace BigWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
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

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Title = "Ведьмак. Последнее желание",
                    Description = "«Последнее желание» — сборник рассказов писателя Анджея Сапковского в жанре фэнтези, объединённых общим " +
                    "персонажем — ведьмаком Геральтом из Ривии. Это первое произведение из цикла «Ведьмак» как по хронологии, так и по " +
                    "времени написания.",
                    ISBN = "978-5-17-148071-4",
                    Author = "Анжей Сапковский",
                    ListPrice = 500,
                    Price = 485,
                    Price50 = 450,
                    Price100 = 400,
                    CategoryId = 7,
                    ImageUrl = "https://imgproxy.patephone.com/pr:sharp/s:470/dpr:2/plain/https://cdru.patephone.com/ru-fast/c/products/701/150/036/075/113/188121_resized1242.jpg?cc=1543189188000"
                });
        }

    }
}
