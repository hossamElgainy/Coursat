using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class DropContentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28965553-5f70-4ba5-b45d-071cfd8b0bcb", "baf937ab-bd9f-4980-a085-2219957df196", "Admin", "admin" },
                    { "b8de7383-6c1b-440e-ad09-fbe51f89612f", "41eba059-674a-48df-aeb3-6823a6afb476", "Strdent", "student" },
                    { "fb2ae336-8daf-4ae9-bdc6-512550fbfaae", "85af378c-6756-41d0-bbde-2894b9833bfe", "Instructor", "instructor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28965553-5f70-4ba5-b45d-071cfd8b0bcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8de7383-6c1b-440e-ad09-fbe51f89612f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb2ae336-8daf-4ae9-bdc6-512550fbfaae");

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseLessonsId = table.Column<int>(type: "int", nullable: true),
                    HtmlContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_CourseLessons_CourseLessonsId",
                        column: x => x.CourseLessonsId,
                        principalTable: "CourseLessons",
                        principalColumn: "Id");
                });

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
                name: "IX_Content_CourseLessonsId",
                table: "Content",
                column: "CourseLessonsId");
        }
    }
}
