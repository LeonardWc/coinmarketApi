using lwc.coinmarket.api.Core.CoinAggregate;

namespace lwc.coinmarket.api.Core.Interfaces;
public interface IBinanceClient
{
  Task<IEnumerable<Coin>> GetCoinsAsync(int limit);
}
