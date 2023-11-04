using lwc.coinmarket.api.Core.CoinAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lwc.coinmarket.api.Infrastructure.Data.Config;

public class CoinConfiguration : IEntityTypeConfiguration<Coin>
{
  public void Configure(EntityTypeBuilder<Coin> builder)
  {
  }
}
