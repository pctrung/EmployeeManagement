using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class AddSeedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "89 Chiaroscuro Rd, Portland, USA", "thomashardy@mail.com", "Thomas Hardy", "(171) 555-222" },
                    { 2, "Obere Str. 57, Berlin, Germany", "dominiqueperrier@mail.com", "Dominique Perrier", "(313) 555-5735" },
                    { 3, "25, Rue lauriston, Paris, France", "mariaanders@mail.com", "Maria Anders", "(503) 555-9931" },
                    { 4, "C/ Araquil, 67, Marid, Spain", "franwilson@mail.com", "Fran Wilson", "(204) 619-5731" },
                    { 5, "Via Monte Blanco 34, Turin, Italy", "martinblank@mail.com", "Martin Blank", "(480) 631-2097" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
