using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lwc.coinmarket.api.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class AddPriceCoin : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropForeignKey(
              name: "FK_Coin_Platform_PlatformId",
              table: "Coin");

          migrationBuilder.DropForeignKey(
              name: "FK_Coin_Quote_QuoteId",
              table: "Coin");

          migrationBuilder.DropForeignKey(
              name: "FK_Tag_Coin_CoinId",
              table: "Tag");

          migrationBuilder.DropPrimaryKey(
              name: "PK_Coin",
              table: "Coin");

          migrationBuilder.RenameTable(
              name: "Coin",
              newName: "Coins");

          migrationBuilder.RenameIndex(
              name: "IX_Coin_QuoteId",
              table: "Coins",
              newName: "IX_Coins_QuoteId");

          migrationBuilder.RenameIndex(
              name: "IX_Coin_PlatformId",
              table: "Coins",
              newName: "IX_Coins_PlatformId");

          migrationBuilder.AddPrimaryKey(
              name: "PK_Coins",
              table: "Coins",
              column: "Id");

          migrationBuilder.CreateTable(
              name: "CoinPrices",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Price = table.Column<double>(type: "float", nullable: false),
                  Volume24h = table.Column<double>(type: "float", nullable: false),
                  VolumeChange24h = table.Column<double>(type: "float", nullable: false),
                  PercentChange1h = table.Column<double>(type: "float", nullable: false),
                  PercentChange24h = table.Column<double>(type: "float", nullable: false),
                  PercentChange7d = table.Column<double>(type: "float", nullable: false),
                  PercentChange30d = table.Column<double>(type: "float", nullable: false),
                  PercentChange60d = table.Column<double>(type: "float", nullable: false),
                  PercentChange90d = table.Column<double>(type: "float", nullable: false),
                  MarketCap = table.Column<double>(type: "float", nullable: false),
                  MarketCapDominance = table.Column<double>(type: "float", nullable: false),
                  FullyDilutedMarketCap = table.Column<double>(type: "float", nullable: false),
                  Tvl = table.Column<double>(type: "float", nullable: true),
                  LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CoinId = table.Column<int>(type: "int", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_CoinPrices", x => x.Id);
              });

          migrationBuilder.AddForeignKey(
              name: "FK_Coins_Platform_PlatformId",
              table: "Coins",
              column: "PlatformId",
              principalTable: "Platform",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);

          migrationBuilder.AddForeignKey(
              name: "FK_Coins_Quote_QuoteId",
              table: "Coins",
              column: "QuoteId",
              principalTable: "Quote",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);

          migrationBuilder.AddForeignKey(
              name: "FK_Tag_Coins_CoinId",
              table: "Tag",
              column: "CoinId",
              principalTable: "Coins",
              principalColumn: "Id");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropForeignKey(
              name: "FK_Coins_Platform_PlatformId",
              table: "Coins");

          migrationBuilder.DropForeignKey(
              name: "FK_Coins_Quote_QuoteId",
              table: "Coins");

          migrationBuilder.DropForeignKey(
              name: "FK_Tag_Coins_CoinId",
              table: "Tag");

          migrationBuilder.DropTable(
              name: "CoinPrices");

          migrationBuilder.DropPrimaryKey(
              name: "PK_Coins",
              table: "Coins");

          migrationBuilder.RenameTable(
              name: "Coins",
              newName: "Coin");

          migrationBuilder.RenameIndex(
              name: "IX_Coins_QuoteId",
              table: "Coin",
              newName: "IX_Coin_QuoteId");

          migrationBuilder.RenameIndex(
              name: "IX_Coins_PlatformId",
              table: "Coin",
              newName: "IX_Coin_PlatformId");

          migrationBuilder.AddPrimaryKey(
              name: "PK_Coin",
              table: "Coin",
              column: "Id");

          migrationBuilder.AddForeignKey(
              name: "FK_Coin_Platform_PlatformId",
              table: "Coin",
              column: "PlatformId",
              principalTable: "Platform",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);

          migrationBuilder.AddForeignKey(
              name: "FK_Coin_Quote_QuoteId",
              table: "Coin",
              column: "QuoteId",
              principalTable: "Quote",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);

          migrationBuilder.AddForeignKey(
              name: "FK_Tag_Coin_CoinId",
              table: "Tag",
              column: "CoinId",
              principalTable: "Coin",
              principalColumn: "Id");
      }
  }
