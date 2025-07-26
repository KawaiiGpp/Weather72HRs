namespace Weather72HRs.Core.Utils
{
    public class ColorRange(List<(double value, Color color)> stops)
    {
        public Color Get(double value)
        {
            int lastIndex = stops.Count - 1;

            if (value <= stops[0].value)
                return stops[0].color;
            if (value >= stops[lastIndex].value)
                return stops[lastIndex].color;

            for (int i = 0; i < lastIndex; i++)
            {
                double from = stops[i].value;
                double to = stops[i + 1].value;

                if (value >= from && value < to)
                {
                    double ratio = (value - from) / (to - from);
                    return ColorUtils.Combine(stops[i].color, stops[i + 1].color, ratio);
                }
            }

            throw new ArgumentException($"Unexpected value: {value}");
        }

        public static readonly ColorRange Temperature = new([
            (-40, Color.Purple),
            (0, Color.Blue),
            (15, Color.Cyan),
            (20, Color.LimeGreen),
            (28, Color.Gold),
            (34, Color.Red),
            (50, Color.Black)]);

        public static readonly ColorRange Humidity = new([
            (0, Color.OrangeRed),
            (35, Color.Gold),
            (55, Color.LimeGreen),
            (70, ColorUtils.Darker(Color.Cyan, 0.9)),
            (90, Color.Blue),
            (100, Color.Purple)]);

        public static readonly ColorRange WindSpeed = new([
            (0.0, ColorUtils.Darker(Color.Cyan, 0.9)),
            (3.4, Color.LimeGreen),
            (10.8, Color.Gold),
            (24.5, Color.Red),
            (41.5, Color.Black)]);
    }
}
