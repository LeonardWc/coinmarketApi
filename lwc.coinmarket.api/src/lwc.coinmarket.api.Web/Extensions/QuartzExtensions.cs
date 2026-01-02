using lwc.coinmarket.api.Web.Jobs;
using Quartz;
using Quartz.AspNetCore;

namespace lwc.coinmarket.api.Web.Extensions;

public static class QuartzExtensions
{
  public static IServiceCollection AddQuartzScheduler(this IServiceCollection services)
  {
    services.AddQuartz(q =>
    {
      // Just use the name of your job that you created in the Jobs folder.
      var jobKey = new JobKey("ImportJob");
      q.AddJob<ImportJob>(opts => opts.WithIdentity(jobKey));

      q.AddTrigger(opts => opts
          .ForJob(jobKey)
          .WithIdentity("ImportJob-trigger")
          //This Cron interval can be described as "run every minute" (when second is zero)
          .WithCronSchedule("0 0/5 * * * ?")
      );
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
