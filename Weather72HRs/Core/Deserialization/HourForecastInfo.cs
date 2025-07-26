using Weather72HRs.Core.Deserialization.Data;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Deserialization
{
    public class HourForecastInfo : WeatherInfo
    {
        public List<HourForecastData> Datas { get; }

        public HourForecastInfo(string rawJson)
            : base(rawJson)
        {
            Datas = GetObject<List<HourForecastData>>("result.hourly_fcsts");
        }

        public List<HourForecastData> Take(int hours)
        {
            Validate.InRange(hours, 0, 72, "API can provide forecasts for only the next 72 hours.");
            return Datas.Take(hours).ToList();
        }

        private static HourForecastInfo? demo;
        public static HourForecastInfo Demo => demo ??= new HourForecastInfo(
            EmbeddedResources.Texts.GetText("next72hrs_snapshot_demo.json"));
    }
}
