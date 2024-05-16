using LMS.External.Interface;
using LMS.External.ScheduledTasks;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.External
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScheduledTasks(this IServiceCollection services)
        {
            
            services.AddSingleton<IScheduledTask, Backup>();

            services.AddHostedService<SchedulerHostedService>();

            return services;
        }
    }
}
