using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BigWebBooksRazor_Temp.Migrations
{
    /// <inheritdoc />
    public partial class CategoryRazorToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Боевик" },
                    { 2, 2, "Ужасы" },
                    { 3, 3, "Мистика" },
                    { 4, 4, "Триллер" },
                    { 5, 5, "Драма" },
                    { 6, 6, "Комедия" },
                    { 7, 7, "Фэнтензи" },
                    { 8, 8, "Фантастика" },
                    { 9, 9, "Нон-фикшн" },
                    { 10, 10, "Научпоп" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
