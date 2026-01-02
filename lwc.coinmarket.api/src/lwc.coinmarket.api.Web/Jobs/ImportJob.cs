using lwc.coinmarket.api.UseCases.Coins.Import;
using MediatR;
using Quartz;

namespace lwc.coinmarket.api.Web.Jobs;
public class ImportJob : IJob
{
  private const int Limit = 400;
  private readonly IMediator _mediator;

  public ImportJob(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task Execute(IJobExecutionContext context)
  {
    await _mediator.Send(new ImportCoinCommand(Limit));
  }
}
