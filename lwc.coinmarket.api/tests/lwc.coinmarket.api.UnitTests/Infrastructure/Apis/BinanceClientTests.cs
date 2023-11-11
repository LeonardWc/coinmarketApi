using AutoMapper;
using lwc.coinmarket.api.Core.Profiles;
using lwc.coinmarket.api.Infrastructure.Apis;
using Xunit;

namespace lwc.coinmarket.api.UnitTests.Infrastructure.Apis;
public class BinanceClientTests
{
  private readonly BinanceClient _binanceClient;
  private readonly IMapper _mapper;

  public BinanceClientTests()
  {
    var mappingConfig = new MapperConfiguration(mc =>
    {
      mc.AddProfile(new CoinProfile());
    });
    _mapper = mappingConfig.CreateMapper();
    HttpClient client = new HttpClient
    {
      BaseAddress = new Uri("https://pro-api.coinmarketcap.com")
    };

    client.DefaultRequestHeaders.TryAddWithoutValidation("X-CMC_PRO_API_KEY", "027212e6-ebb2-469f-8008-1ce7333f5895");

    _binanceClient = new BinanceClient(client, _mapper);
  }

  [Fact]
  public void ExtractCoinFromJsonFile()
  {
    string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Samples\coin.json");
    string filePath = Path.GetFullPath(file);
    string coinDatas = File.ReadAllText(filePath);

    var coins = _binanceClient.ExtractCoin(coinDatas);

    Assert.NotNull(coins);
  }

  [Fact(Skip = "Done")]
  public async Task GetCoinsAsyncTests()
  {
    var coins = await _binanceClient.GetCoinsAsync(200);

    Assert.NotNull(coins);
  }
}
