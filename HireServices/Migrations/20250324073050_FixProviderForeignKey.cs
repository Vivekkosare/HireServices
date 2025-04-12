using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireServices.Migrations
{
    /// <inheritdoc />
    public partial class FixProviderForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId1",
                table: "ProviderServices");

            migrationBuilder.DropIndex(
                name: "IX_ProviderServices_ProviderId1",
                table: "ProviderServices");

            migrationBuilder.DropColumn(
                name: "ProviderId1",
                table: "ProviderServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId1",
                table: "ProviderServices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProviderServices_ProviderId1",
                table: "ProviderServices",
                column: "ProviderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId1",
                table: "ProviderServices",
                column: "ProviderId1",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
