using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Services
{
    public interface ITravelService
    {
        Task<TravelResponse> CreateTravelPlanAsync(TravelRequest request);
    }
}

