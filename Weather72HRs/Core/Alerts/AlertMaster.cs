using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Alerts.Instance;
using Weather72HRs.Core.Deserialization;

namespace Weather72HRs.Core.Alerts
{
    public class AlertMaster
    {
        public static readonly AlertMaster Instance = new();

        private readonly List<Alert> alerts = [];

        private AlertMaster()
        {
            alerts.Add(new HeatAlert());
            alerts.Add(new ColdAlert());
            alerts.Add(new GaleAlert());
            alerts.Add(new ColdWaveAlert());
            alerts.Add(new HailAlert());
            alerts.Add(new RainStormAlert());
            alerts.Add(new LightningAlert());
            alerts.Add(new WildFireAlert());
        }

        public List<AlertItem> GetActiveItems(HourForecastInfo info)
        {
            return alerts
                .Select(alert => alert.Evaluate(info))
                .Where(item => item != null)
                .Select(item => item!)
                .ToList();
        }

        public List<AlertItem> GetAllItems()
        {
            List<AlertItem> result = [];
            alerts.ForEach(alert => result.AddRange(alert.Items));
            return result;
        }
    }
}
