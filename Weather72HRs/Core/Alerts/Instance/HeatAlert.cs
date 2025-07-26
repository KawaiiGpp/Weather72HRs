using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Deserialization;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class HeatAlert() : Alert("高温", "heat")
    {
        private readonly int minimumHits = 3;

        public override void Initialize()
        {
            QuickRegister(AlertLevel.Red, "极端酷热", 39, 46);
            QuickRegister(AlertLevel.Orange, "酷热", 37, 42);
            QuickRegister(AlertLevel.Yellow, "炎热", 35, 39);
            QuickRegister(AlertLevel.Blue, "闷热", 33, 35);
        }

        private void QuickRegister(AlertLevel lvl, string hot, int temp, int feel)
        {
            AlertDescription desc = new()
            {
                Title = $"天气可能或已经变得{hot}。",
                Descriptions =
                    [
                        $"未来24小时内，最高体感温度达到{feel}°C以上",
                        $"未来24小时内，最高气温达到{temp}°C以上"
                    ]
            };

            bool predicate(HourForecastInfo info) => info
                .Take(24)
                .Count(data => data.Temperature >= temp || data.FeelsLikeImproved >= feel)
                >= minimumHits;

            AlertItem alert = new()
            {
                Level = lvl,
                Category = Category,
                ImageCategory = ImageCategory,
                Predicate = predicate,
                Description = desc
            };

            Register(alert);
        }
    }
}
