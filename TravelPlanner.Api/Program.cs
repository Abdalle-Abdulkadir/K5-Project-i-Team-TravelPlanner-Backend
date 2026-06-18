using Scalar.AspNetCore;
using TravelPlanner.Api.Data;
using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Services.GrokAIService;
using TravelPlanner.Api.Services.TravelService;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Add OpenAPI support for Scalar
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


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
