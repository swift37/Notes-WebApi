using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;
using Notes.DAL.Context;

namespace Notes.DAL
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlServer(configuration["DbConnection"]);
            })
            .AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());
    }
}
