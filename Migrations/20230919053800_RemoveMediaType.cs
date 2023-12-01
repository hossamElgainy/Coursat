using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMediaType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropForeignKey(
                name: "FK_CourseLessons_MediaType_MediaTypeId",
                table: "CourseLessons");

            migrationBuilder.DropTable(
                name: "MediaType");*/

            migrationBuilder.DropIndex(
                name: "IX_CourseLessons_MediaTypeId",
                table: "CourseLessons");

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
                name: "MediaTypeId",
                table: "CourseLessons");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1047af39-f005-4301-8817-0fc993435960", "cc34f201-90de-4b1f-9315-7bf430125fc4", "Instructor", "instructor" },
                    { "5b1e91fd-5842-4927-b3b6-27cfd7e78cc2", "536b3473-ff5d-44ba-8942-5eb8af3e9662", "Admin", "admin" },
                    { "8d6e2347-1a4c-4958-aa3d-10366be6f05d", "3c188d11-afbd-4fc6-9278-8322453678bb", "Student", "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1047af39-f005-4301-8817-0fc993435960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1e91fd-5842-4927-b3b6-27cfd7e78cc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6e2347-1a4c-4958-aa3d-10366be6f05d");

            migrationBuilder.AddColumn<int>(
                name: "MediaTypeId",
                table: "CourseLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbnailImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.Id);
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
                name: "IX_CourseLessons_MediaTypeId",
                table: "CourseLessons",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseLessons_MediaType_MediaTypeId",
                table: "CourseLessons",
                column: "MediaTypeId",
                principalTable: "MediaType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
