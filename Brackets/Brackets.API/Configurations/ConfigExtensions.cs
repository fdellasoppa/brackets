using Brackets.API.Matches;
using Brackets.API.Errors;
using Brackets.Application.Matches;
using Brackets.Infrastructure.Data;
using Brackets.Infrastructure.Matches;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

namespace Brackets.API.Configurations;

public static class ConfigExtensions
{

    public static WebApplication ConfigServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

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

		//var mongoDbSettings = builder.Configuration
		//    .GetSection(nameof(MongoDbSettings))
		//.Get<MongoDbSettings>();

		builder.Services.AddOptions();
        builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection(nameof(MongoDbSettings))
            );

        builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
        builder.Services.AddTransient<IMatchService, MatchService>();
		// TODO: Who should map repos? Application layer or infra maybe?
		builder.Services.AddTransient<IMatchRepository, MatchRepository>();

        //builder.Services.AddControllers(options =>
        //{
        //    options.Filters.Add<HttpResponseExceptionFilter>();
        //});

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

        app.Run();
    }
}
