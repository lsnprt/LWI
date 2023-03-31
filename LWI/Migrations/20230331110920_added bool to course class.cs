using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LWI.Migrations
{
    /// <inheritdoc />
    public partial class addedbooltocourseclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEco",
                table: "Courses",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEco",
                table: "Courses");
        }
    }
}
