using Ardalis.Result;
using Ardalis.SharedKernel;
using lwc.coinmarket.api.Core.Interfaces;
using lwc.coinmarket.api.UseCases.Coins.Import;
using MediatR;
using Microsoft.Extensions.Logging;

namespace lwc.coinmarket.api.UseCases.Coins.Create;

public class ImportCoinHandler : ICommandHandler<ImportCoinCommand, Result<bool>>
{
  private readonly IBinanceClient _client;
  private readonly IMediator _mediator;
  private readonly ILogger<ImportCoinHandler> _logger;

  public ImportCoinHandler(IBinanceClient client, IMediator mediator, ILogger<ImportCoinHandler> logger)
  {
    _client = client;
    _mediator = mediator;
    _logger = logger;
  }

  public async Task<Result<bool>> Handle(ImportCoinCommand request,CancellationToken cancellationToken)
  {
    var coins = await _client.GetCoinsAsync(request.numbefOfCoins).ConfigureAwait(false);

    foreach(var coin in coins)
    {
       var result =  await _mediator.Send(new CreateCoinCommand(coin));

      if(!result.IsSuccess)
      {
        _logger.LogError("Failed to create the coin : '{0}'", coin?.name);
      }
    }

    return true;
  }
}
