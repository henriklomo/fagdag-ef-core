using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FagDag.EfCore.Database.Migrations
{
    /// <inheritdoc />
    public partial class newattribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusicType",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicType",
                table: "Events");
        }
    }
}
