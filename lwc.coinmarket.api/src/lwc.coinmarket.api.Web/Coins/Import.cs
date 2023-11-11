//using lwc.coinmarket.api.Core.ContributorAggregate;
//using Ardalis.SharedKernel;
//using FastEndpoints;
//using lwc.coinmarket.api.Web.Endpoints.ContributorEndpoints;
//using lwc.coinmarket.api.UseCases.Contributors.List;
//using lwc.coinmarket.api.UseCases.Contributors.Create;
//using MediatR;
//using lwc.coinmarket.api.Core.CoinAggregate;

//namespace lwc.coinmarket.api.Web.Coins;

///// <summary>
///// Create a new Contributor
///// </summary>
///// <remarks>
///// Creates a new Contributor given a name.
///// </remarks>
//public class Import : Endpoint<CreateContributorRequest, CreateContributorResponse>
//{
//  private readonly IRepository<Coin> _repository;
//  private readonly IMediator _mediator;

//  public Import(IRepository<Coin> repository,
//    IMediator mediator)
//  {
//    _repository = repository;
//    _mediator = mediator;
//  }

//  public override void Configure()
//  {
//    Post(CreateContributorRequest.Route);
//    AllowAnonymous();
//    Summary(s =>
//    {
//      // XML Docs are used by default but are overridden by these properties:
//      //s.Summary = "Create a new Contributor.";
//      //s.Description = "Create a new Contributor. A valid name is required.";
//      s.ExampleRequest = new CreateContributorRequest { Name = "Contributor Name" };
//    });
//  }

//  public override async Task HandleAsync(
//    CreateContributorRequest request,
//    CancellationToken cancellationToken)
//  {
//    var result = await _mediator.Send(new CreateContributorCommand(request.Name!));

//    if (result.IsSuccess)
//    {
//      Response = new CreateContributorResponse(result.Value, request.Name!);
//      return;
//    }
//    // TODO: Handle other cases as necessary
//  }
//}
