using TravelPlanner.Api.Models;
using Microsoft.Extensions.Configuration;


namespace TravelPlanner.Api.Services.GrokAIService
{
    public class GrokAIService : IGrokAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public GrokAIService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public Task<TravelResponse> GenerateTravelPlanAsync(TravelRequest request)
        {
            return Task.FromResult(new TravelResponse
            {
                Summary = "Mock AI response",
                TraceId = Guid.NewGuid().ToString(),
            });
        }
    }
}
