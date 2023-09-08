using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behavior;
using System.Reflection;

namespace Notes.Application
{
    public static class ApplicationRegistrator
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) => services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() })
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
