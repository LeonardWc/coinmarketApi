using Ardalis.SharedKernel;
using AutoMapper;
using lwc.coinmarket.api.Core.CoinAggregate;
using lwc.coinmarket.api.Core.Profiles;
using lwc.coinmarket.api.UseCases.Coins.Create;
using MediatR;
using NSubstitute;
using Xunit;

namespace lwc.coinmarket.api.UnitTests.UseCases.Coins.Create;

public class CreateCoinHandlerTests
{
  private readonly IRepository<Coin> _repository;
  private readonly IMediator _mediator;
  private readonly CreateCoinHandler _handler;

  public CreateCoinHandlerTests()
  {
    _repository = Substitute.For<IRepository<Coin>>();
    _mediator = Substitute.For<IMediator>();
    var mapperConfig = new MapperConfiguration(mc =>
    {
      mc.AddProfile(new CoinProfile());
    });
    var mapper = mapperConfig.CreateMapper();
    _handler = new CreateCoinHandler(_repository, mapper, _mediator);
  }

  [Fact]
  public async Task Handle_ShouldBeOk()
  {

  }
}
