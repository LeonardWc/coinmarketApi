using AutoMapper;
using lwc.coinmarket.api.Core.Profiles;
using lwc.coinmarket.api.Core.Services;
using Xunit;

namespace lwc.coinmarket.api.UnitTests.Core.Services;
public class ImportCoinServiceTests
{
  private readonly ImportCoinService _importCoinService;
  private readonly IMapper _mapper;

  public ImportCoinServiceTests()
  {
    var mappingConfig = new MapperConfiguration(mc =>
    {
      mc.AddProfile(new CoinProfile());
    });
    _mapper = mappingConfig.CreateMapper();
    _importCoinService = new ImportCoinService(_mapper);
  }

  [Fact]
  public void ExtractCoinFromJsonFile()
  {
    string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Samples\coin.json");
    string filePath = Path.GetFullPath(file);
    string coinDatas = File.ReadAllText(filePath);

    var coins = _importCoinService.ExtractCoin(coinDatas);

    Assert.NotNull(coins);
  }
}
