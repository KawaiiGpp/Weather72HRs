using Weather72HRs.Core.Deserialization;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Alerts.Base
{
    public abstract class Alert
    {
        private readonly List<AlertItem> items = [];

        public List<AlertItem> Items => new(items);
        public string Category { get; }
        public string ImageCategory { get; }

        public Alert(string category, string imageCategory)
        {
            Category = category;
            ImageCategory = imageCategory;

            Initialize();
        }

        public void Register(AlertItem item)
        {
            int index = item.Level.ImageIndex;
            string identifier = $"{item.Category}_{index}";

            Validate.NotContains(items, item,
                $"Item {identifier} is already registered.");
            Validate.Ensure(items.Count == 0 || item.Level.ImageIndex + 1 == items[^1].Level.ImageIndex,
                $"Item {identifier}'s index must be exactly 1 lower than the last item.");

            items.Add(item);
        }

        public AlertItem? Evaluate(HourForecastInfo info)
        {
            return items.FirstOrDefault(item => item.Predicate(info));
        }

        public abstract void Initialize();
    }
}
