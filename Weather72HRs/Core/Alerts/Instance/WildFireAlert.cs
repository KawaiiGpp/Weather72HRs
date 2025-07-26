using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class WildFireAlert() : Alert("火险", "wildfire")
    {
        public override void Initialize()
        {
            QuickRegister(AlertLevel.Red, "非常高", 24, 7, 6);
            QuickRegister(AlertLevel.Orange, "高", 48, 5, 12);
            QuickRegister(AlertLevel.Yellow, "较高", 72, 3, 18);
        }

        private void QuickRegister(AlertLevel lvl, 
            string fire, int hours, int score, int minimumHits)
        {
            AlertDescription desc = new()
            {
                Title = $"森林火险等级维持在{fire}。",
                Descriptions =
                    [
                        $"未来{hours}小时内，森林火险可能维持在{fire}"
                    ]
            };

            AlertItem alert = new()
            {
                Level = lvl,
                Category = Category,
                ImageCategory = ImageCategory,
                Predicate = info => info
                    .Take(hours)
                    .Select(data => WeatherEvaluation.EvaluateWildFireScore(
                        data.Temperature, data.Precipitation, 
                        data.RelativeHumidity, data.ImprovedWindInfo.WindLevel))
                    .Count(result => result >= score)
                    >= minimumHits,
                Description = desc
            };

            Register(alert);
        }

        
    }
}
