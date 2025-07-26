using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Deserialization;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class RainStormAlert() : Alert("暴雨", "rainstorm")
    {
        private readonly int minimumHits = 2;

        public override void Initialize()
        {
            QuickRegister(AlertLevel.Orange, 3, "特大暴雨", ["12", "25"]);
            QuickRegister(AlertLevel.Yellow, 3, "大暴雨", ["11", "24"]);
            QuickRegister(AlertLevel.Blue, 6, "暴雨", ["10", "23"]);
        }

        private void QuickRegister(AlertLevel lvl, int hours, string rain, string[] codes)
        {
            AlertDescription desc = new()
            {
                Title = $"未来可能或已经出现{rain}。",
                Descriptions =
                    [
                        $"未来{hours}小时内，可能出现{rain}天气"
                    ]
            };

            bool predicate(HourForecastInfo info) => info
                .Take(hours)
                .Count(data => codes.Contains(data.Code))
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
