using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lwc.coinmarket.api.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class UpdateCoin : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropForeignKey(
              name: "FK_Coins_Platform_PlatformId",
              table: "Coins");

          migrationBuilder.AlterColumn<int>(
              name: "PlatformId",
              table: "Coins",
              type: "int",
              nullable: true,
              oldClrType: typeof(int),
              oldType: "int");

          migrationBuilder.AddForeignKey(
              name: "FK_Coins_Platform_PlatformId",
              table: "Coins",
              column: "PlatformId",
              principalTable: "Platform",
              principalColumn: "Id");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropForeignKey(
              name: "FK_Coins_Platform_PlatformId",
              table: "Coins");

          migrationBuilder.AlterColumn<int>(
              name: "PlatformId",
              table: "Coins",
              type: "int",
              nullable: false,
              defaultValue: 0,
              oldClrType: typeof(int),
              oldType: "int",
              oldNullable: true);

          migrationBuilder.AddForeignKey(
              name: "FK_Coins_Platform_PlatformId",
              table: "Coins",
              column: "PlatformId",
              principalTable: "Platform",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);
      }
  }
