using Weather72HRs.Core.Deserialization.Data;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Deserialization
{
    public class RealtimeInfo : WeatherInfo
    {
        public RealtimeData Data { get; }

        public RealtimeInfo(string rawJson)
            : base(rawJson)
        {
            Data = GetObject<RealtimeData>("result.realtime");
        }

        private static RealtimeInfo? demo;
        public static RealtimeInfo Demo => demo ??= new RealtimeInfo(
            EmbeddedResources.Texts.GetText("realtime_snapshot_demo.json"));
    }
}
