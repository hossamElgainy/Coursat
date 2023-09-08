using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class updateCourseLessonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fa5d812-1417-4ec9-b7b9-2b313215b2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a94c92e7-56cd-4da2-974c-3ec97c090193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddfc1a0c-bd2e-418c-a260-5140171db354");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CourseLessons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03cfce05-1b8d-465e-b857-72c427dd0d05", "14538dba-dc06-4dd2-a38a-1df7b84d229b", "Admin", "admin" },
                    { "1a1cfbc5-066c-44bc-81a6-26604010eac6", "beaab554-8b4e-4bb6-8e47-84a2d603b72b", "Instructor", "instructor" },
                    { "71e04eb2-2282-4803-a9ad-cabb3beea4e7", "df141500-8812-42e8-9081-3c4eea840b07", "Student", "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03cfce05-1b8d-465e-b857-72c427dd0d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1cfbc5-066c-44bc-81a6-26604010eac6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e04eb2-2282-4803-a9ad-cabb3beea4e7");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CourseLessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fa5d812-1417-4ec9-b7b9-2b313215b2ce", "0c9fb424-3c2c-4242-9338-7ab757f5c2a9", "Student", "student" },
                    { "a94c92e7-56cd-4da2-974c-3ec97c090193", "b9ea57bb-20b4-428d-ab8f-2000c42c4e63", "Instructor", "instructor" },
                    { "ddfc1a0c-bd2e-418c-a260-5140171db354", "90183fb8-9395-4ad5-b405-e8d0e1177484", "Admin", "admin" }
                });
        }
    }
}
