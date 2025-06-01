using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireServices.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPriceColumnDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProviderServices",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProviderServices",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");
        }
    }
}
