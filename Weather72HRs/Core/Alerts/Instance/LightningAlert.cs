using Weather72HRs.Core.Alerts.Base;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class LightningAlert() : Alert("雷电", "lightning")
    {
        public override void Initialize()
        {
            QuickRegister(AlertLevel.Yellow, "强雷电", "05");
            QuickRegister(AlertLevel.Blue, "雷电", "04");
        }

        private void QuickRegister(AlertLevel lvl, string lightning, string codes)
        {
            AlertDescription desc = new()
            {
                Title = $"可能或已经出现{lightning}天气。",
                Descriptions =
                    [
                        $"未来2小时内，存在出现{lightning}天气的可能性"
                    ]
            };

            AlertItem alert = new()
            {
                Level = lvl,
                Category = Category,
                ImageCategory = ImageCategory,
                Predicate = info => info
                    .Take(2)
                    .Any(data => data.Code == codes),
                Description = desc
            };

            Register(alert);
        }
    }
}
