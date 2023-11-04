using AutoMapper;
using lwc.coinmarket.api.Core.CoinAggregate;
using lwc.coinmarket.api.Core.Models;

namespace lwc.coinmarket.api.Core.Profiles;
public class CoinProfile : Profile
{
  public CoinProfile()
  {
    CreateMap<DatumJson, Coin>()
      .ForMember(x => x.NumMarketPairs, y => y.MapFrom(map => map.num_market_pairs))
      .ForMember(x => x.DateAdded, y => y.MapFrom(map => map.date_added))
      .ForMember(x => x.MaxSupply, y => y.MapFrom(map => map.max_supply))
      .ForMember(x => x.CirculatingSupply, y => y.MapFrom(map => map.circulating_supply))
      .ForMember(x => x.TotalSupply, y => y.MapFrom(map => map.total_supply))
      .ForMember(x => x.InfiniteSupply, y => y.MapFrom(map => map.infinite_supply))
      .ForMember(x => x.CmcRank, y => y.MapFrom(map => map.cmc_rank))
      .ForMember(x => x.SelfReportedCirculatingSupply, y => y.MapFrom(map => map.self_reported_circulating_supply))
      .ForMember(x => x.SelfReportedMarketCap, y => y.MapFrom(map => map.self_reported_market_cap))
      .ForMember(x => x.TvlRatio, y => y.MapFrom(map => map.tvl_ratio))
      .ForMember(x => x.LastUpdated, y => y.MapFrom(map => map.last_updated))
      .ReverseMap();

    CreateMap<PlatformJson, Platform>()
      .ForMember(x => x.Token_address, y => y.MapFrom(map => map.token_address))
      .ReverseMap();

    CreateMap<QuoteJson, Quote>()
      .ForMember(x => x.USD, y => y.MapFrom(map => map.USD))
      .ReverseMap();

    CreateMap<USDJson, USD>()
      .ForMember(x => x.Volume24h, y => y.MapFrom(map => map.volume_24h))
      .ForMember(x => x.VolumeChange24h, y => y.MapFrom(map => map.volume_change_24h))
      .ForMember(x => x.PercentChange1h, y => y.MapFrom(map => map.percent_change_1h))
      .ForMember(x => x.PercentChange24h, y => y.MapFrom(map => map.percent_change_24h))
      .ForMember(x => x.PercentChange7d, y => y.MapFrom(map => map.percent_change_7d))
      .ForMember(x => x.PercentChange30d, y => y.MapFrom(map => map.percent_change_30d))
      .ForMember(x => x.PercentChange60d, y => y.MapFrom(map => map.percent_change_60d))
      .ForMember(x => x.PercentChange90d, y => y.MapFrom(map => map.percent_change_90d))
      .ForMember(x => x.MarketCap, y => y.MapFrom(map => map.market_cap))
      .ForMember(x => x.MarketCapDominance, y => y.MapFrom(map => map.market_cap_dominance))
      .ForMember(x => x.FullyDilutedMarketCap, y => y.MapFrom(map => map.fully_diluted_market_cap))
      .ForMember(x => x.LastUpdated, y => y.MapFrom(map => map.last_updated))
      .ReverseMap();

    CreateMap<string, Tag>()
    .ConstructUsing(str => new Tag { Name = str })
    .ReverseMap();
  }
}
