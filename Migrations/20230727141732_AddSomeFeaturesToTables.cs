using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursat.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeFeaturesToTables : Migration
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
                keyValue: "28965553-5f70-4ba5-b45d-071cfd8b0bcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8de7383-6c1b-440e-ad09-fbe51f89612f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb2ae336-8daf-4ae9-bdc6-512550fbfaae");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegestrationDate",
                table: "UserCourse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "CourseLessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RegestrationDate",
                table: "UserCourse");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "CourseLessons");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28965553-5f70-4ba5-b45d-071cfd8b0bcb", "baf937ab-bd9f-4980-a085-2219957df196", "Admin", "admin" },
                    { "b8de7383-6c1b-440e-ad09-fbe51f89612f", "41eba059-674a-48df-aeb3-6823a6afb476", "Strdent", "student" },
                    { "fb2ae336-8daf-4ae9-bdc6-512550fbfaae", "85af378c-6756-41d0-bbde-2894b9833bfe", "Instructor", "instructor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_CreatedBy",
                table: "Course",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
