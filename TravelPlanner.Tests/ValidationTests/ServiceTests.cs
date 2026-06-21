using Microsoft.Extensions.Caching.Memory;
using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;
using TravelPlanner.Api.Services.GrokAIService;
using TravelPlanner.Api.Services.TravelService;

namespace TravelPlanner.Tests.ValidationTests;

public class ServiceTests
{
    [Fact]
    public async Task FirstRequest_CallsGrokAIService()
    {
        // Given
        var fakeGrok = new FakeGrokAIService();
        var cache = new MemoryCache(new MemoryCacheOptions());
        var service = new TravelService(null!, fakeGrok, cache);

        var request = CreateValidRequest();

        // When
        var result = await service.GetDestinationsAsync(request);

        // Then
        Assert.NotNull(result);
        Assert.Equal(1, fakeGrok.GetDestinationsCallCount);
    }

    [Fact]
    public async Task SecondSameRequest_UsesCache()
    {
        // Given
        var fakeGrok = new FakeGrokAIService();
        var cache = new MemoryCache(new MemoryCacheOptions());
        var service = new TravelService(null!, fakeGrok, cache);

        var request = CreateValidRequest();

        // When
        await service.GetDestinationsAsync(request);
        await service.GetDestinationsAsync(request);

        // Then
        Assert.Equal(1, fakeGrok.GetDestinationsCallCount);
    }

    private static DestinationRequestDto CreateValidRequest()
    {
        return new DestinationRequestDto
        {
            Budget = 5000,
            Days = 5,
            DepartureDate = DateTime.Today.AddDays(1)
        };
    }

    private class FakeGrokAIService : IGrokAIService
    {
        public int GetDestinationsCallCount { get; private set; }

        public Task<DestinationResponseDto> GetDestinationsAsync(DestinationRequestDto request)
        {
            GetDestinationsCallCount++;

            return Task.FromResult(new DestinationResponseDto
            {
                Summary = "Test summary",
                Destinations = new List<string> { "Paris", "Rome", "Madrid" },
                QualityNotes = "Test note" ,
                TraceId = "test-trace-id"
            });
        }

        public Task<TravelPlanResponseDto> CreateTravelPlanAsync(TravelPlanRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}

