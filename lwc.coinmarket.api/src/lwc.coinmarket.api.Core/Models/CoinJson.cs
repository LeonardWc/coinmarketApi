using lwc.coinmarket.api.Core.CoinAggregate;

namespace lwc.coinmarket.api.Core.Models;

public class CoinDto
{
  public int id { get; set; }
  public string name { get; set; } = default!;
  public string symbol { get; set; } = default!;
  public string slug { get; set; } = default!;
  public int num_market_pairs { get; set; }
  public DateTime date_added { get; set; }
  public List<string> tags { get; set; } = default!;
  public long? max_supply { get; set; }
  public double circulating_supply { get; set; }
  public double total_supply { get; set; }
  public bool infinite_supply { get; set; }
  public PlatformJson platform { get; set; } = default!;
  public int cmc_rank { get; set; }
  public double? self_reported_circulating_supply { get; set; }
  public double? self_reported_market_cap { get; set; }
  public double? tvl_ratio { get; set; }
  public DateTime last_updated { get; set; }
  public QuoteJson quote { get; set; } = default!;
}

public class PlatformJson
{
  public int id { get; set; }
  public string name { get; set; } = default!;
  public string symbol { get; set; } = default!;
  public string slug { get; set; } = default!;
  public string token_address { get; set; } = default!;
}

public class QuoteJson
{
  public USDJson USD { get; set; } = default!;
}

public class CoinJson
{
  public StatusJson status { get; set; } = default!;
  public List<CoinDto> data { get; set; } = default!;
}

public class StatusJson
{
  public DateTime timestamp { get; set; }
  public int error_code { get; set; }
  public string error_message { get; set; } = default!;
  public int elapsed { get; set; }
  public int credit_count { get; set; }
  public string notice { get; set; } = default!;
  public int total_count { get; set; }
}

public class USDJson
{
  public double price { get; set; }
  public double volume_24h { get; set; } 
  public double volume_change_24h { get; set; }
  public double percent_change_1h { get; set; }
  public double percent_change_24h { get; set; }
  public double percent_change_7d { get; set; }
  public double percent_change_30d { get; set; }
  public double percent_change_60d { get; set; }
  public double percent_change_90d { get; set; }
  public double market_cap { get; set; }
  public double market_cap_dominance { get; set; }
  public double fully_diluted_market_cap { get; set; }
  public double? tvl { get; set; }
  public DateTime last_updated { get; set; }
}

