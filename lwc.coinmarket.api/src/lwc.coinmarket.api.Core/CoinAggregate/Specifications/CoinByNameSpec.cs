using Ardalis.Specification;

namespace lwc.coinmarket.api.Core.CoinAggregate.Specifications;

public class CoinByNameSpec : Specification<Coin>
{
  public CoinByNameSpec(string name)
  {
    Query
        .Where(coin => coin.Name == name);
  }
}
