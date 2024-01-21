﻿using AutoMapper;
using lwc.coinmarket.api.Core.CoinAggregate;
using lwc.coinmarket.api.Core.Interfaces;
using lwc.coinmarket.api.Core.Models;
using MediatR;
using Newtonsoft.Json;

namespace lwc.coinmarket.api.Core.Services;
public class ImportCoinService : IImportCoinService
{
  private readonly IMapper _mapper;

  public ImportCoinService(IMapper mapper)
  {
    _mapper = mapper;
  }

  public IEnumerable<Coin> ExtractCoin(string data)
  {
    var coinJsons = JsonConvert.DeserializeObject<CoinJson>(data);
    var result = coinJsons?.data.Select(_mapper.Map<Coin>) ?? Enumerable.Empty<Coin>();

    //var result = await _mediator.Send(new CreateContributorCommand(request.Name!));

    //if (result.IsSuccess)
    //{
    //  Response = new CreateContributorResponse(result.Value, request.Name!);
    //  return;
    //}

    return result;
  }
}
