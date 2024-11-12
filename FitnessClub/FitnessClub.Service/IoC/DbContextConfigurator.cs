using FitnessClub.FitnessClub.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.FitnessClub.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        string connectionString = configuration.GetValue<string>("ConnectionStrings:FitnessClubDbContext");

        builder.Services.AddDbContextFactory<FitnessClubDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped
        );
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<FitnessClubDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}