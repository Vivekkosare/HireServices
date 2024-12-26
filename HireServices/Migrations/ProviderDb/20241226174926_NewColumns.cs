using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireServices.Migrations.ProviderDb
{
    /// <inheritdoc />
    public partial class NewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderServices_Providers_ServiceProviderId",
                table: "ProviderServices");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderId",
                table: "ProviderServices",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderServices_ServiceProviderId",
                table: "ProviderServices",
                newName: "IX_ProviderServices_ProviderId");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Providers",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CustomersServed",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HighlightedServices",
                table: "Providers",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LatestReviews",
                table: "Providers",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "ServiceCategories",
                table: "Providers",
                type: "TEXT[]",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId1",
                table: "ProviderServices",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ServiceCategories",
                table: "Providers",
                column: "ServiceCategories")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ServiceTags",
                table: "Providers",
                column: "ServiceTags")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderServices_ProviderId1",
                table: "ProviderServices",
                column: "ProviderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId",
                table: "ProviderServices",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId1",
                table: "ProviderServices",
                column: "ProviderId1",
                principalTable: "Providers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId",
                table: "ProviderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId1",
                table: "ProviderServices");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ServiceCategories",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ServiceTags",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_ProviderServices_ProviderId1",
                table: "ProviderServices");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CustomersServed",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "HighlightedServices",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LatestReviews",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ServiceCategories",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderId1",
                table: "ProviderServices");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProviderServices",
                newName: "ServiceProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderServices_ProviderId",
                table: "ProviderServices",
                newName: "IX_ProviderServices_ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderServices_Providers_ServiceProviderId",
                table: "ProviderServices",
                column: "ServiceProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
