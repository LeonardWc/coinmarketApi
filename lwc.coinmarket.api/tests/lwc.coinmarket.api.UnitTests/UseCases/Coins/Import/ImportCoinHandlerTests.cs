using lwc.coinmarket.api.Core.Interfaces;
using lwc.coinmarket.api.Core.Models;
using lwc.coinmarket.api.UnitTests.Samples;
using lwc.coinmarket.api.UseCases.Coins.Create;
using lwc.coinmarket.api.UseCases.Coins.Import;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace lwc.coinmarket.api.UnitTests.UseCases.Coins.Import;

public class ImportCoinHandlerTests
{
  private readonly IBinanceClient _client;
  private readonly IMediator _mediator;
  private readonly ILogger<ImportCoinHandler> _logger;
  private readonly ImportCoinHandler _handler;

  public ImportCoinHandlerTests()
  {
    _client = Substitute.For<IBinanceClient>();
    _mediator = Substitute.For<IMediator>();
    _logger = Substitute.For<ILogger<ImportCoinHandler>>();

    _handler = new ImportCoinHandler(_client, _mediator, _logger);
  }

  [Fact]
  public async Task Handle_ShouldReturnSuccess()
  {
    _client.GetCoinsAsync(Arg.Any<int>()).Returns(CoinHelper.GetSampleCoins());
    _mediator.Send(Arg.Any<CreateCoinCommand>(), Arg.Any<CancellationToken>()).Returns(await Task.FromResult(1));
    var request = new ImportCoinCommand(200);

    var result = await _handler.Handle(request, new CancellationToken());

    Assert.True(result);
  }
}
