using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using lwc.coinmarket.api.Core.CoinAggregate;
using lwc.coinmarket.api.Core.CoinAggregate.Events;
using lwc.coinmarket.api.Core.CoinAggregate.Specifications;
using MediatR;

namespace lwc.coinmarket.api.UseCases.Coins.Create;

public class CreateCoinHandler : ICommandHandler<CreateCoinCommand, Result<int>>
{
  private readonly IRepository<Coin> _repository;
  private readonly IMapper _mapper;
  private readonly IMediator _mediator;

  public CreateCoinHandler(IRepository<Coin> repository, IMapper mapper, IMediator mediator)
  {
    _repository = repository;
    _mapper = mapper;
    _mediator = mediator;
  }

  public async Task<Result<int>> Handle(CreateCoinCommand request,CancellationToken cancellationToken)
  {
    var coin = _mapper.Map<Coin>(request.coin);

    var spec = new CoinByNameSpec(coin.Name);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    var coinId = entity?.Id;

    if (entity == null)
    {
      var result = await _repository.AddAsync(coin, cancellationToken);
      coinId = result.Id;
    }

    var domainPriceEvent = _mapper.Map<PriceAddedEvent>(coin.Quote.USD);
    domainPriceEvent.CoinId = coinId.GetValueOrDefault();
    await _mediator.Publish(domainPriceEvent);
    
    return Result.Success(coin.Id);
  }
}
