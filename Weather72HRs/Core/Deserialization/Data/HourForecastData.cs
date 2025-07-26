using Newtonsoft.Json;

namespace Weather72HRs.Core.Deserialization.Data
{
    public class HourForecastData : WeatherData
    {
        [JsonProperty("temp_fc")]
        public required override double Temperature { get; init; }

        [JsonProperty("data_time")]
        public required string DataTime { get; init; }
    }
}
