namespace lwc.coinmarket.api.Core.CoinAggregate;
public class Platform
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public string Symbol { get; set; } = default!;
  public string Slug { get; set; } = default!;
  public string Token_address { get; set; } = default!;
}
