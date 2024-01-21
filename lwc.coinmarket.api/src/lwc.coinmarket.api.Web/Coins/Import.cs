using FastEndpoints;
using lwc.coinmarket.api.UseCases.Coins.Import;
using MediatR;

namespace lwc.coinmarket.api.Web.Coins;

/// <summary>
/// Create a new Contributor
/// </summary>
/// <remarks>
/// Creates a new Contributor given a name.
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
      s.ExampleRequest = new ImportCoinRequest { Limit = 100 };
    });
  }

  public override async Task HandleAsync(
    ImportCoinRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ImportCoinCommand(request.Limit));

    if (result.IsSuccess)
    {
      Response = new ImportCoinResponse(result.Value);
      return;
    }
  }
}
