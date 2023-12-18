using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BigWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://imgproxy.patephone.com/pr:sharp/s:470/dpr:2/plain/https://cdru.patephone.com/ru-fast/c/products/701/150/036/075/113/188121_resized1242.jpg?cc=1543189188000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 2, "Анжей Сапковский", 7, "«Cборник рассказов Анджея Сапковского в жанре фэнтези, объединённых общим персонажем — ведьмаком Геральтом из Ривии. Это второе произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. В этой части Геральт впервые встречает Цири и находит своё предназначение.", "978-5-17-118208-3", 400.0, 385.0, 300.0, 350.0, "Ведьмак. Меч предназначения" },
                    { 3, "Анжей Сапковский", 7, "«Третья книга из цикла «Ведьмак» польского писателя Анджея Сапковского.", "978-5-17-118219-9", 400.0, 385.0, 300.0, 350.0, "Ведьмак. Кровь эльфов" },
                    { 4, "Анжей Сапковский", 7, "«Четвёртая книга из цикла «Ведьмак» польского писателя Анджея Сапковского", "978-5-17-118219-9", 650.0, 625.0, 525.0, 575.0, "Ведьмак. Час презрения" }
                });
        }
    }
}
