using Microsoft.Extensions.Logging;

namespace TravelPlanner.Api.Logging
{
    public class AIRequestLogger
    {
        private readonly ILogger _logger;
        public AIRequestLogger(ILogger<AIRequestLogger> logger)
        {
            _logger = logger;
        }


        public void LogSuccess(int statusCode, long latencyMs, string traceId)
        {
            _logger.LogInformation(
                "AI request successful. StatusCode={StatusCode}, LatencyMs={LatencyMs}, TraceId={TraceId}",
                statusCode,
                latencyMs,
                traceId);
        }

        public void LogTimeout(long latencyMs, string traceId)
        {
            _logger.LogWarning(
                "AI request timed out.  StatusCode={StatusCode}, LatencyMs={LatencyMs}, TraceId={TraceId}",
                504,
                latencyMs,
                traceId);
        }

        public void LogFailure(int statusCode, long latencyMs, string traceId)
        {
            _logger.LogError(
                "AI request failed. StatusCode={StatusCode}, LatencyMs={LatencyMs}, TraceId={TraceId}",
                statusCode,
                latencyMs,
                traceId);
        }

    }
}
