namespace Weather72HRs.Core.Web
{
    public class WeatherResponse(string? rawJson, Exception? exception)
    {
        public string? RawJson { get; } = rawJson;
        public Exception? ExceptionCaught { get; } = exception;

        public static WeatherResponse From(string rawJson) => new(rawJson, null);
        public static WeatherResponse From(Exception exception) => new(null, exception);
    }
}
