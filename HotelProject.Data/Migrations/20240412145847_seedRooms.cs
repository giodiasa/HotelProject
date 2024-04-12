using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "HotelId", "LastName" },
                values: new object[,]
                {
                    { 1, "გიორგი", 1, "გიორგაძე" },
                    { 2, "თამაზი", 2, "გოდერძიშვილი" },
                    { 3, "გოირგი", 3, "გუჯარელიძე" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "DailyPrice", "HotelId", "IsFree", "Name" },
                values: new object[,]
                {
                    { 1, 50.0, 1, false, "A-100" },
                    { 2, 50.0, 1, false, "A-200" },
                    { 3, 50.0, 1, true, "A-300" },
                    { 4, 100.0, 1, true, "B-100" },
                    { 5, 100.0, 1, false, "B-200" },
                    { 6, 100.0, 1, false, "B-300" },
                    { 7, 200.0, 1, true, "C-100" },
                    { 8, 200.0, 1, false, "C-200" },
                    { 9, 200.0, 1, false, "C-300" },
                    { 10, 25.0, 2, true, "100" },
                    { 11, 25.0, 2, true, "101" },
                    { 12, 25.0, 2, false, "102" },
                    { 13, 50.0, 2, true, "200" },
                    { 14, 50.0, 2, false, "201" },
                    { 15, 50.0, 2, false, "202" },
                    { 16, 75.0, 2, true, "300" },
                    { 17, 75.0, 2, true, "301" },
                    { 18, 75.0, 2, true, "302" },
                    { 19, 150.0, 3, false, "A-10" },
                    { 20, 150.0, 3, true, "A-20" },
                    { 21, 150.0, 3, true, "A-30" },
                    { 22, 150.0, 3, false, "B-10" },
                    { 23, 150.0, 3, false, "B-20" },
                    { 24, 150.0, 3, true, "B-30" },
                    { 25, 150.0, 3, true, "C-10" },
                    { 26, 150.0, 3, false, "C-20" },
                    { 27, 150.0, 3, true, "C-30" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
