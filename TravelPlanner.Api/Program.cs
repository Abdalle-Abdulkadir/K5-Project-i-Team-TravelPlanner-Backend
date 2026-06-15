using Scalar.AspNetCore;
using TravelPlanner.Api.Services;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Add OpenAPI support for Scalar
builder.Services.AddOpenApi();

builder.Services.AddScoped<ITravelService, TravelService>();
builder.Services.AddScoped<IGrokAIService, GrokAIService>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Enable Scalar only in development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
