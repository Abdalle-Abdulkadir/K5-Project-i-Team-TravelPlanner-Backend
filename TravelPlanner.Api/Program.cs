using Scalar.AspNetCore;
using TravelPlanner.Api.Data;
using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Services.GrokAIService;
using TravelPlanner.Api.Services.TravelService;
using TravelPlanner.Api.Middleware;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using TravelPlanner.Api.Logging;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure CORS to allow requests from the frontend application
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//Add OpenAPI support for Scalar
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ITravelService, TravelService>();
builder.Services.AddScoped<IGrokAIService, GrokAIService>();
builder.Services.AddScoped<AIRequestLogger>();

builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.ContentType = "application/json";

        await context.HttpContext.Response.WriteAsJsonAsync(new
        {
            Message = "Too many requests. Please try again later."
        }, token);
    };

    options.AddSlidingWindowLimiter("TravelPolicy", limiterOptions =>
    {
        limiterOptions.PermitLimit = 2;
        limiterOptions.Window = TimeSpan.FromSeconds(5);
        limiterOptions.SegmentsPerWindow = 6;
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = 0;
    });
});




var app = builder.Build();


// Global exception handling for unhandled errors
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseRateLimiter();

app.UseCors("FrontendPolicy");

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
