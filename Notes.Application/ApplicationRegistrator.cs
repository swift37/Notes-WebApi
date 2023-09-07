using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Notes.Application
{
    public static class ApplicationRegistrator
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) => services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
