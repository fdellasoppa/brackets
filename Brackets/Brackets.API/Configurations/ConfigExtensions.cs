﻿using Brackets.API.Matches;
using Brackets.API.Errors;
using Brackets.Infrastructure.Data;
using Brackets.Infrastructure.Configuration;
using Brackets.Application.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Brackets.API.Tournaments;

namespace Brackets.API.Configurations;

public static class ConfigExtensions
{

    public static WebApplication ConfigServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Brackets API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

		var initialScopes = builder.Configuration
            .GetValue<string>("DownstreamApi:Scopes")?
            .Split(' ');

		builder.Services
            .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
            .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
			.AddMicrosoftGraph(builder.Configuration.GetSection("DownstreamApi"))
			//.AddDownstreamWebApi()
			.AddInMemoryTokenCaches();

        builder.Services.AddControllers();

		builder.Services.AddOptions();
        builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection(nameof(MongoDbSettings))
            );

        builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
        builder.Services.ConfigServices();
        builder.Services.ConfigRepositories();

        return builder.Build();
    }

    public static void StartApplication(this WebApplication app)
    {
        app.UseExceptionHandler();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapMatchEndpoints();
        app.MapTournamentEndpoints();

        app.Run();
    }
}
