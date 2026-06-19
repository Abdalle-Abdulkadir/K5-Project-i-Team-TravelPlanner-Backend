namespace TravelPlanner.Api.Exceptions;

public class AppException : Exception
{
    public int StatusCode { get; }

    public AppException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    // AI errors
    public static AppException AuthenticationFailed()
        => new("AI authentication failed. Check your API key.", 503);

    public static AppException RateLimitReached()
        => new("AI rate limit reached. Please try again later.", 429);

    public static AppException UnexpectedError()
        => new("AI service returned an unexpected error.", 503);

    public static AppException Timeout()
        => new("AI request timed out. Please try again later.", 504);
}






