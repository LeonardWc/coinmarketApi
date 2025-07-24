using Autofac.Core;
using Quartz;
using Quartz.AspNetCore;

namespace lwc.coinmarket.api.Web.Extensions;

public static class QuartzExtensions
{
  public static IServiceCollection AddQuartzScheduler(this IServiceCollection services)
  {
    services.AddQuartz(q =>
    {
      // base Quartz scheduler, job and trigger configuration
    });

    // ASP.NET Core hosting
    services.AddQuartzServer(options =>
    {
      // when shutting down we want jobs to complete gracefully
      options.WaitForJobsToComplete = true;
    });

    return services;
  }
}
