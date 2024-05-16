using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using MediatR;
using LMS.Business.Common.Behaviours;
using LMS.Business.Components;
using LMS.Business.Interface;

namespace LMS.Business
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserComponent, UserComponent>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMemoryCache();
            return services;
        }
    }
}
