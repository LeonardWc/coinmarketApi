using lwc.coinmarket.api.Core.CoinAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lwc.coinmarket.api.Infrastructure.Data.Config;

public class CoinPriceConfiguration : IEntityTypeConfiguration<CoinPrice>
{
  public void Configure(EntityTypeBuilder<CoinPrice> builder)
  {
  }
}
