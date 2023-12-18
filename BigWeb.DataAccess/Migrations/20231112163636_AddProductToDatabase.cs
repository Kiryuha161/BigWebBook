using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BigWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Анжей Сапковский", "«Последнее желание» — сборник рассказов писателя Анджея Сапковского в жанре фэнтези, объединённых общим персонажем — ведьмаком Геральтом из Ривии. Это первое произведение из цикла «Ведьмак» как по хронологии, так и по времени написания.", "978-5-17-148071-4", 500.0, 485.0, 400.0, 450.0, "Ведьмак. Последнее желание" },
                    { 2, "Анжей Сапковский", "«Cборник рассказов Анджея Сапковского в жанре фэнтези, объединённых общим персонажем — ведьмаком Геральтом из Ривии. Это второе произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. В этой части Геральт впервые встречает Цири и находит своё предназначение.", "978-5-17-118208-3", 400.0, 385.0, 300.0, 350.0, "Ведьмак. Меч предназначения" },
                    { 3, "Анжей Сапковский", "«Третья книга из цикла «Ведьмак» польского писателя Анджея Сапковского.", "978-5-17-118219-9", 400.0, 385.0, 300.0, 350.0, "Ведьмак. Кровь эльфов" },
                    { 4, "Анжей Сапковский", "«Четвёртая книга из цикла «Ведьмак» польского писателя Анджея Сапковского", "978-5-17-118219-9", 650.0, 625.0, 525.0, 575.0, "Ведьмак. Час презрения" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
