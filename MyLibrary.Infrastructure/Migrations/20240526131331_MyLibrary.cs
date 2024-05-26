using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MyLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CurrentPage", "Description", "FinishedDate", "Pages", "StartedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Chugong", 143, "", null, 320, null, "Solo Leveling" },
                    { 2, "Tsugumi Ohba", 629, "", null, 2400, null, "Death Note" },
                    { 3, "Hirohiko Araki", 1204, "", null, 3260, null, "JoJo's Bizarre Adventure Part 6: Stone Ocean" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
