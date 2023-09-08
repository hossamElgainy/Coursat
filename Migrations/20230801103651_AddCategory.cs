using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a777f2-5837-48e4-a65c-1098c823d2f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da711315-0d2f-4654-ae00-41d937de633d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae22300-be2d-4803-8fd3-f5b07cf2b8fd");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fa5d812-1417-4ec9-b7b9-2b313215b2ce", "0c9fb424-3c2c-4242-9338-7ab757f5c2a9", "Student", "student" },
                    { "a94c92e7-56cd-4da2-974c-3ec97c090193", "b9ea57bb-20b4-428d-ab8f-2000c42c4e63", "Instructor", "instructor" },
                    { "ddfc1a0c-bd2e-418c-a260-5140171db354", "90183fb8-9395-4ad5-b405-e8d0e1177484", "Admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Course_CategoryId",
                table: "Course");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95a777f2-5837-48e4-a65c-1098c823d2f9", "783bc230-b57e-4ca7-88ce-abc6081d1d7c", "Admin", "admin" },
                    { "da711315-0d2f-4654-ae00-41d937de633d", "5c8fe9cd-aa66-438b-b9f6-3a6fbba93f15", "Student", "student" },
                    { "fae22300-be2d-4803-8fd3-f5b07cf2b8fd", "066afd05-c26a-4056-81c0-3331ba1f3aae", "Instructor", "instructor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
