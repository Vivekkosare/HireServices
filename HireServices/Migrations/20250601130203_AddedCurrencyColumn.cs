using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireServices.Migrations
{
    /// <inheritdoc />
    public partial class AddedCurrencyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "ProviderServices",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "ProviderServices");
        }
    }
}
