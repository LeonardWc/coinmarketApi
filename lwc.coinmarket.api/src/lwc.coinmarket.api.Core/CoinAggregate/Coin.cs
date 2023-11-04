using Ardalis.SharedKernel;

namespace lwc.coinmarket.api.Core.CoinAggregate;
public class Coin : EntityBase, IAggregateRoot
{
  public string Name { get; set; } = default!;
  public string Symbol { get; set; } = default!;
  public string Slug { get; set; } = default!;
  public int NumMarketPairs { get; set; }
  public DateTime DateAdded { get; set; }
  public List<Tag> Tags { get; set; } = default!;
  public long? MaxSupply { get; set; }
  public double CirculatingSupply { get; set; }
  public double TotalSupply { get; set; }
  public bool InfiniteSupply { get; set; }
  public Platform Platform { get; set; } = default!;
  public int CmcRank { get; set; }
  public double? SelfReportedCirculatingSupply { get; set; }
  public double? SelfReportedMarketCap { get; set; }
  public double? TvlRatio { get; set; }
  public DateTime LastUpdated { get; set; }
  public Quote Quote { get; set; } = default!;
}
