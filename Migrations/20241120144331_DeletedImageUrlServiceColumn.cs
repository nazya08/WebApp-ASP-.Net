using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppVSCode.Migrations
{
    /// <inheritdoc />
    public partial class DeletedImageUrlServiceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
