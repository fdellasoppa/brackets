using Brackets.API.Configurations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.ConfigServices();

app.StartApplication();

