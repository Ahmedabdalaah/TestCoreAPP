using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreAPP.Migrations
{
    /// <inheritdoc />
    public partial class addroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d8f6ae3-8ed7-43a8-ae61-0504811c14b5", "0600b16e-a431-4669-b498-623d23be2bda", "Admin", "admin" },
                    { "fd082c38-653d-448c-a37a-69a8ed09fc3d", "3dddea8f-34b5-406d-8d49-c3becf7efdea", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d8f6ae3-8ed7-43a8-ae61-0504811c14b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd082c38-653d-448c-a37a-69a8ed09fc3d");
        }
    }
}
