using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Deserialization;
using Weather72HRs.Core.Deserialization.Data;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class ColdWaveAlert() : Alert("寒潮", "coldwave")
    {
        private readonly int minimumHits = 2;

        public override void Initialize()
        {
            QuickRegister(AlertLevel.Red, "非常剧烈", 14, 8, 16, 5);
            QuickRegister(AlertLevel.Orange, "剧烈", 10, 8, 12, 5);
            QuickRegister(AlertLevel.Yellow, "明显", 8, 12, 10, 8);
            QuickRegister(AlertLevel.Blue, "较明显", 6, 15, 8, 12);
        }

        private void QuickRegister(AlertLevel lvl, string drop,
            int dropTemp, int lowestTemp, int dropFeel, int lowestFeel)
        {
            AlertDescription desc = new()
            {
                Title = $"未来可能迎来{drop}的降温。",
                Descriptions =
                    [
                        $"未来48小时内，气温降幅达{dropTemp}°C以上，最低{lowestTemp}°C或以下",
                        $"未来48小时内，体感温度降幅达{dropFeel}°C以上，最低{lowestFeel}°C或以下"
                    ]
            };

            bool forTemp(HourForecastInfo info) => Check(info, d => d.Temperature, dropTemp, lowestTemp);
            bool forFeel(HourForecastInfo info) => Check(info, d => d.FeelsLikeImproved, dropFeel, lowestFeel);

            AlertItem alert = new()
            {
                Level = lvl,
                Category = Category,
                ImageCategory = ImageCategory,
                Predicate = info => forTemp(info) || forFeel(info),
                Description = desc
            };

            Register(alert);
        }

        private bool Check(HourForecastInfo info, Func<HourForecastData, double> f, int drop, int lowest)
        {
            List<double> datas = info.Take(48).Select(f).ToList();

            return Enumerable
                .Range(0, 24)
                .Count(i => datas[i + 24] + drop <= datas[i] && datas[i + 24] <= lowest)
                >= minimumHits;
        }
    }
}
