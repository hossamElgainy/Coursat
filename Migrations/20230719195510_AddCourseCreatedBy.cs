using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b69e36a-644c-4fa1-8d78-9fd77802b2e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d8053b8-4da3-4af5-9036-02e8949d6d10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be42ca5b-a776-4feb-8e17-458874d1571f");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44efb776-da0e-4de0-b0e9-d817021edbd6", "bdfd74df-d658-4d85-974c-5ca7edb6e05c", "Admin", "admin" },
                    { "9646443f-55ea-4d7f-9a6f-a9a45bcc61b2", "bf119e9a-5960-42e8-9d45-5c02c6336c96", "Strdent", "student" },
                    { "9aa5eda5-c56e-46eb-80dc-8451b29c37ae", "90fa7ca7-bdaa-466a-8af4-c8c47d759f3e", "Instructor", "instructor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CreatedBy",
                table: "Course",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CreatedBy",
                table: "Course");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44efb776-da0e-4de0-b0e9-d817021edbd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9646443f-55ea-4d7f-9a6f-a9a45bcc61b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa5eda5-c56e-46eb-80dc-8451b29c37ae");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Course");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b69e36a-644c-4fa1-8d78-9fd77802b2e4", "1e8d7212-a82c-43de-932c-ab6745911e9a", "Admin", "admin" },
                    { "9d8053b8-4da3-4af5-9036-02e8949d6d10", "16dc2191-aad2-4011-b08e-a37caed12387", "Instructor", "instructor" },
                    { "be42ca5b-a776-4feb-8e17-458874d1571f", "bf0f1fa8-9fa4-4613-a33a-13faaf451e14", "Strdent", "student" }
                });
        }
    }
}
