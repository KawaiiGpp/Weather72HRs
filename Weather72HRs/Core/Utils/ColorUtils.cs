namespace Weather72HRs.Core.Utils
{
    public static class ColorUtils
    {
        public static Color Darker(Color color, double ratio)
        {
            Validate.Ensure(ratio >= 0, $"Ratio cannot be lower than 0: {ratio}");

            int r = (int)(color.R * ratio);
            int g = (int)(color.G * ratio);
            int b = (int)(color.B * ratio);

            return Color.FromArgb(r, g, b);
        }

        public static bool IsDarkColor(Color color)
        {
            return (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) < 128;
        }

        public static Color GetFore(Color back)
        {
            return IsDarkColor(back) ? Color.White : Color.Black;
        }

        public static Color Combine(Color from, Color to, double ratio)
        {
            Validate.InRange(ratio, 0.0, 1.0, "Ratio must be from 0.0f to 1.0f.");

            int r = (int)Math.Round(from.R * (1 - ratio) + to.R * ratio);
            int g = (int)Math.Round(from.G * (1 - ratio) + to.G * ratio);
            int b = (int)Math.Round(from.B * (1 - ratio) + to.B * ratio);

            return Color.FromArgb(r, g, b);
        }
    }
}
