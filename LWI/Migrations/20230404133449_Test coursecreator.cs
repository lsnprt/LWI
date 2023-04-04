using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LWI.Migrations
{
    /// <inheritdoc />
    public partial class Testcoursecreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "CourseCreatorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCreatorId",
                table: "Courses",
                column: "CourseCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CourseCreatorId",
                table: "Courses",
                column: "CourseCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CourseCreatorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseCreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseCreatorId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
