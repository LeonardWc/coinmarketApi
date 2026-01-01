using lwc.coinmarket.api.Core.Models;
using Newtonsoft.Json;

namespace lwc.coinmarket.api.UnitTests.Samples;

public static class CoinHelper
{
  public static IEnumerable<CoinDto> GetSampleCoins()
  {
    string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Samples\coin.json");
    string filePath = Path.GetFullPath(file);
    string coinDatas = File.ReadAllText(filePath);

    var coinJsons = JsonConvert.DeserializeObject<CoinJson>(coinDatas);

    return coinJsons?.data.Select(x => x) ?? Enumerable.Empty<CoinDto>();
  }
}
