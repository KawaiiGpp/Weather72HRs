using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Deserialization;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class GaleAlert() : Alert("大风", "gale")
    {
        public override void Initialize()
        {
            QuickRegister(AlertLevel.Red, "风力可能或已增大至飓风或以上。", 12, 2);
            QuickRegister(AlertLevel.Orange, "风力可能或已增大至烈风或暴风。", 9, 3);
            QuickRegister(AlertLevel.Yellow, "风力可能或已增大至强风以上。", 6, 4);
            QuickRegister(AlertLevel.Blue, "风力可能增大或已明显增大。", 4, 5);
        }

        private void QuickRegister(AlertLevel lvl, string title, int level, int minimumHits)
        {
            AlertDescription desc = new()
            {
                Title = title,
                Descriptions =
                    [
                        $"未来24小时内，风力将达到或超过{level}级"
                    ]
            };

            bool predicate(HourForecastInfo info) => info
                .Take(24).Count(data => data.ImprovedWindInfo.WindLevel >= level)
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
