using FastEndpoints;
using lwc.coinmarket.api.UseCases.Coins.Import;
using MediatR;

namespace lwc.coinmarket.api.Web.Coins;

/// <summary>
/// Import Cryptocurrency
/// </summary>
/// <remarks>
/// Cryptocurrency.
/// </remarks>
public class Import : Endpoint<ImportCoinRequest, ImportCoinResponse>
{
  private readonly IMediator _mediator;

  public Import(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(ImportCoinRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new ImportCoinRequest { Limit = 200 };
    });
  }

  public override async Task HandleAsync(
    ImportCoinRequest request,
    CancellationToken cancellationToken)
  {
    await _mediator.Send(new ImportCoinCommand(request.Limit));

    Response = new ImportCoinResponse(true);
    return;
  }
}
