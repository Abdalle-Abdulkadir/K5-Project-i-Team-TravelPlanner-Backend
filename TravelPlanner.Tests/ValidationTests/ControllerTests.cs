using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Api.Controllers;
using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;
using TravelPlanner.Api.Services.TravelService;

namespace TravelPlanner.Tests.ValidationTests;

public class ControllerTests
{
    [Fact]
    public async Task GetDestinations_ValidRequest_ReturnsOk()
    {
        // Given
        var fakeService = new FakeTravelService();
        var controller = new TravelController(fakeService);

        var request = new DestinationRequestDto
        {
            Budget = 5000,
            Days = 5,
            DepartureDate = DateTime.Today.AddDays(1)
        };

        // When
        var result = await controller.GetDestinations(request);

        // Then
        Assert.IsType<OkObjectResult>(result);
        Assert.True(fakeService.GetDestinationsWasCalled);
    }

    [Fact]
    public async Task GetDestinations_InvalidModelState_ReturnsBadRequest()
    {
        // Given
        var fakeService = new FakeTravelService();
        var controller = new TravelController(fakeService);

        controller.ModelState.AddModelError("Budget", "Budget is required");

        var request = new DestinationRequestDto();

        // When
        var result = await controller.GetDestinations(request);

        // Then
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.False(fakeService.GetDestinationsWasCalled);
    }

    private class FakeTravelService : ITravelService
    {
        public bool GetDestinationsWasCalled { get; private set; }

        public Task<DestinationResponseDto> GetDestinationsAsync(DestinationRequestDto request)
        {
            GetDestinationsWasCalled = true;
            return Task.FromResult(new DestinationResponseDto());
        }

        public Task<TravelPlanResponseDto> CreateTravelPlanAsync(TravelPlanRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}

