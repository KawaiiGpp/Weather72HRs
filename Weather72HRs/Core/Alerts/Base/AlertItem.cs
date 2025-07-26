using Weather72HRs.Core.Deserialization;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Alerts.Base
{
    public class AlertItem
    {
        public required AlertLevel Level { get; init; }
        public required string Category { get; init; }
        public required string ImageCategory { get; init; }
        public required Predicate<HourForecastInfo> Predicate { get; init; }
        public required AlertDescription Description { get; init; }

        public string ImageName => $"{ImageCategory}_{Level.ImageIndex}.png";
        public string DisplayName => $"{Category}{Level.Color}";
        public Image Image => EmbeddedResources.Alerts.GetImage(ImageName);
    }
}
