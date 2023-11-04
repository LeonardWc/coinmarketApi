using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lwc.coinmarket.api.Infrastructure.Migrations;

/// Add-Migration [MigrationName] -StartupProject lwc.coinmarket.api.Web -Context AppDbContext -Project lwc.coinmarket.api.Infrastructure
/// <inheritdoc />
public partial class AddCoin : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "Platform",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Token_address = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Platform", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "USD",
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
                  LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_USD", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "Quote",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  USDId = table.Column<int>(type: "int", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Quote", x => x.Id);
                  table.ForeignKey(
                      name: "FK_Quote_USD_USDId",
                      column: x => x.USDId,
                      principalTable: "USD",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
              });

          migrationBuilder.CreateTable(
              name: "Coin",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  NumMarketPairs = table.Column<int>(type: "int", nullable: false),
                  DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                  MaxSupply = table.Column<long>(type: "bigint", nullable: true),
                  CirculatingSupply = table.Column<double>(type: "float", nullable: false),
                  TotalSupply = table.Column<double>(type: "float", nullable: false),
                  InfiniteSupply = table.Column<bool>(type: "bit", nullable: false),
                  PlatformId = table.Column<int>(type: "int", nullable: false),
                  CmcRank = table.Column<int>(type: "int", nullable: false),
                  SelfReportedCirculatingSupply = table.Column<double>(type: "float", nullable: true),
                  SelfReportedMarketCap = table.Column<double>(type: "float", nullable: true),
                  TvlRatio = table.Column<double>(type: "float", nullable: true),
                  LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                  QuoteId = table.Column<int>(type: "int", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Coin", x => x.Id);
                  table.ForeignKey(
                      name: "FK_Coin_Platform_PlatformId",
                      column: x => x.PlatformId,
                      principalTable: "Platform",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
                  table.ForeignKey(
                      name: "FK_Coin_Quote_QuoteId",
                      column: x => x.QuoteId,
                      principalTable: "Quote",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
              });

          migrationBuilder.CreateTable(
              name: "Tag",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CoinId = table.Column<int>(type: "int", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Tag", x => x.Id);
                  table.ForeignKey(
                      name: "FK_Tag_Coin_CoinId",
                      column: x => x.CoinId,
                      principalTable: "Coin",
                      principalColumn: "Id");
              });

          migrationBuilder.CreateIndex(
              name: "IX_Coin_PlatformId",
              table: "Coin",
              column: "PlatformId");

          migrationBuilder.CreateIndex(
              name: "IX_Coin_QuoteId",
              table: "Coin",
              column: "QuoteId");

          migrationBuilder.CreateIndex(
              name: "IX_Quote_USDId",
              table: "Quote",
              column: "USDId");

          migrationBuilder.CreateIndex(
              name: "IX_Tag_CoinId",
              table: "Tag",
              column: "CoinId");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "Tag");

          migrationBuilder.DropTable(
              name: "Coin");

          migrationBuilder.DropTable(
              name: "Platform");

          migrationBuilder.DropTable(
              name: "Quote");

          migrationBuilder.DropTable(
              name: "USD");
      }
  }
