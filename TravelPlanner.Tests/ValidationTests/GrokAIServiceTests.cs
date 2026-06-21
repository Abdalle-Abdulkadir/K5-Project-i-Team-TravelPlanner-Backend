using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net;
using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.Exceptions;
using TravelPlanner.Api.Logging;
using TravelPlanner.Api.Services.GrokAIService;

namespace TravelPlanner.Tests.ValidationTests;

public class GrokAIServiceTests
{
    [Fact]
    public async Task ValidGrokResponse_ParsesIntoDestinationResponseDto()
    {
        // Given
        var service = CreateService(HttpStatusCode.OK, """
        {
          "choices": [
            {
              "message": {
                "content": "Paris, Rome, Madrid"
              }
            }
          ]
        }
        """);

        var request = CreateValidRequest();

        // When
        var result = await service.GetDestinationsAsync(request);

        // Then
        Assert.NotNull(result);
        Assert.Equal(3, result.Destinations.Count);
    }

    [Fact]
    public async Task InvalidApiKey_ThrowsAuthenticationFailedException()
    {
        // Given
        var service = CreateService(HttpStatusCode.Unauthorized, "{}");
        var request = CreateValidRequest();

        // When
        var exception = await Assert.ThrowsAsync<AppException>(() =>
            service.GetDestinationsAsync(request));

        // Then
        Assert.Equal(503, exception.StatusCode);
        Assert.Contains("authentication failed", exception.Message.ToLower());
    }

    private static GrokAIService CreateService(HttpStatusCode statusCode, string responseContent)
    {
        var httpClient = new HttpClient(new FakeHttpMessageHandler(statusCode, responseContent))
        {
            BaseAddress = new Uri("https://fake-url.com")
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["GrokAI:ApiKey"] = "fake-key",
                ["GrokAI:BaseUrl"] = "https://fake-url.com",
                ["GrokAI:EndpointPath"] = "/chat"
            })
            .Build();

        var logger = new AIRequestLogger(NullLogger<AIRequestLogger>.Instance);

        return new GrokAIService(httpClient, configuration, logger);
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

    private class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _responseContent;

        public FakeHttpMessageHandler(HttpStatusCode statusCode, string responseContent)
        {
            _statusCode = statusCode;
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_responseContent)
            });
        }
    }
}
