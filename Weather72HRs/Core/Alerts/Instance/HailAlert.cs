using Weather72HRs.Core.Alerts.Base;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class HailAlert() : Alert("冰雹", "hail")
    {
        public override void Initialize()
        {
            AlertDescription desc = new()
            {
                Title = $"可能或已经出现冰雹天气。",
                Descriptions =
                    [
                        $"未来2小时内，存在出现冰雹天气的可能性"
                    ]
            };

            AlertItem alert = new()
            {
                Level = AlertLevel.Yellow,
                Category = Category,
                ImageCategory = ImageCategory,
                Predicate = info => info.Take(2).Any(data => data.Code == "05"),
                Description = desc
            };

            Register(alert);
        }
    }
}
