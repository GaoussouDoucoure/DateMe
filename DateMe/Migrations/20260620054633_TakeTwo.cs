using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DateMe.Migrations
{
    /// <inheritdoc />
    public partial class TakeTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* This is after the Initial Migration and I went to delete Occupation from Application.cs
               and from DatingApplication.cshtml, because if it's deleted from Application.cs it has to be
               deleted in the Views too; then ran a Migration TakeTwo and now updating the database with that.*/
            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Applications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
