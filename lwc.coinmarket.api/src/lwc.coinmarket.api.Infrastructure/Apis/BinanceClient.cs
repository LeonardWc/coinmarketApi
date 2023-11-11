using AutoMapper;
using lwc.coinmarket.api.Core.CoinAggregate;
using lwc.coinmarket.api.Core.Interfaces;
using lwc.coinmarket.api.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace lwc.coinmarket.api.Infrastructure.Apis;
public class BinanceClient : IBinanceClient
{
  private readonly HttpClient _httpClient;
  private readonly IMapper _mapper;

  public BinanceClient(HttpClient httpClient, IMapper mapper)
  {
    _mapper = mapper;
    _httpClient = httpClient;
  }

  public async Task<IEnumerable<Coin>> GetCoinsAsync(int limit)
  {
    using HttpResponseMessage response = await _httpClient.GetAsync($"/v1/cryptocurrency/listings/latest?start=1&limit={limit}");
    response.EnsureSuccessStatusCode();

    var jsonResponse = await response.Content.ReadAsStringAsync();
    return ExtractCoin(jsonResponse);
  }

  public IEnumerable<Coin> ExtractCoin(string data)
  {
    var coinJsons = JsonConvert.DeserializeObject<CoinJson>(data);
    var result = coinJsons?.data.Select(_mapper.Map<Coin>) ?? Enumerable.Empty<Coin>();

    return result;
  }
}
