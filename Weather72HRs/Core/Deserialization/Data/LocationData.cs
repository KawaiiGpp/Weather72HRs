using Newtonsoft.Json;

namespace Weather72HRs.Core.Deserialization.Data
{
    public class LocationData
    {
        [JsonProperty("areacode")]
        public required string AreaCode { get; init; }

        [JsonProperty("name")]
        public required string Name { get; init; }

        [JsonProperty("country")]
        public required string Country { get; init; }

        [JsonProperty("path")]
        public required string Path { get; init; }
    }
}
