using Newtonsoft.Json;

namespace Weather72HRs.Core.Deserialization.Data
{
    public class RealtimeData : WeatherData
    {
        [JsonProperty("temp")]
        public required override double Temperature { get; init; }

        [JsonProperty("prec_time")]
        public required string PrecipitationTime { get; init; }

        [JsonProperty("vis")]
        public required int Visibility { get; init; }

        [JsonProperty("dew")]
        public required int DewPoint { get; init; }

        [JsonProperty("uv")]
        public required int UvIndex { get; init; }

        [JsonProperty("weight")]
        public required int Weight { get; init; }

        [JsonProperty("brief")]
        public required string Brief { get; init; }

        [JsonProperty("detail")]
        public required string Detail { get; init; }
    }
}
