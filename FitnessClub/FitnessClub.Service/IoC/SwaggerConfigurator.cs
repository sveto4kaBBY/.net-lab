﻿namespace FitnessClub.FitnessClub.Service.IoC;

public class SwaggerConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}