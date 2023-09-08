using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class addUserLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Course",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Website = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Github = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StackoverFlow = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ca0c651-b032-464c-9f4b-50c388ab4057", "3afcf9fd-a235-456d-9b96-babb82678081", "Student", "student" },
                    { "e1e1cbb9-a9af-4121-946e-fccf8ab8ddf8", "92c9fdad-0f64-4e49-8382-26a44c4c8028", "Admin", "admin" },
                    { "f81aaa03-425a-49dd-9c3e-e5ed3d261611", "9b5de922-08c1-48ee-8b37-efc66e7fa233", "Instructor", "instructor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ca0c651-b032-464c-9f4b-50c388ab4057");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e1cbb9-a9af-4121-946e-fccf8ab8ddf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81aaa03-425a-49dd-9c3e-e5ed3d261611");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Course");

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
    }
}
