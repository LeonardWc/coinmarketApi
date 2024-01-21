using Ardalis.SharedKernel;
using AutoMapper;
using lwc.coinmarket.api.Core.CoinAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace lwc.coinmarket.api.Core.CoinAggregate.Handlers;

internal class PriceAddedHandler : INotificationHandler<PriceAddedEvent>
{
  private readonly ILogger<PriceAddedHandler> _logger;
  private readonly IRepository<CoinPrice> _repository;
  private readonly IMapper _mapper;

  public PriceAddedHandler(ILogger<PriceAddedHandler> logger, IRepository<CoinPrice> repository, IMapper mapper)
  {
    _logger = logger;
    _repository = repository; 
    _mapper = mapper;
  }

  public async Task Handle(PriceAddedEvent domainEvent, CancellationToken cancellationToken)
  {
    var coinPrice = _mapper.Map<CoinPrice>(domainEvent);

    await _repository.AddAsync(coinPrice, cancellationToken);
  }
}
