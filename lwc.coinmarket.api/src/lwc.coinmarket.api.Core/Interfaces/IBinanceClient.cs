using lwc.coinmarket.api.Core.CoinAggregate;
using lwc.coinmarket.api.Core.Models;

namespace lwc.coinmarket.api.Core.Interfaces;
public interface IBinanceClient
{
  Task<IEnumerable<CoinDto>> GetCoinsAsync(int limit);
}
