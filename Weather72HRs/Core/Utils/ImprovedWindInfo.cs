using Weather72HRs.Core.Deserialization.Data;

namespace Weather72HRs.Core.Utils
{
    public class ImprovedWindInfo
    {
        public int WindLevel { get; }
        public string WindLevelAsString { get; }
        public string WindDirection { get; }

        public ImprovedWindInfo(double speed, int angle)
        {
            Validate.Ensure(speed >= 0, "Wind speed cannot be lower than 0.");
            Validate.InRange(angle, 0, 360, "Wind angle must be from 0 to 360.");

            WindLevel = CalculateLevel(speed);
            WindLevelAsString = GetLevelAsString();
            WindDirection = CalculateAngle(angle);
        }

        private int CalculateLevel(double speed)
        {
            double[] stops =
            [
                0.3, 1.6, 3.4, 5.5, 8.0, 10.8, 13.9, 17.2, 20.8,
                24.5, 28.5, 32.7, 36.9, 41.4, 46.1, 50.9, 56.0, 61.3
            ];

            int index = Array.BinarySearch(stops, speed);
            return index >= 0 ? index + 1 : ~index;
        }

        private string GetLevelAsString()
        {
            if (WindLevel <= 0) return "≤1级";
            else if (WindLevel < 18) return $"{WindLevel}-{WindLevel + 1}级";
            else return "≥18级";
        }

        private string CalculateAngle(int angle)
        {
            string[] directions =
            [
                "北风", "北东北风", "东北风", "东东北风",
                "东风", "东东南风", "东南风", "南东南风",
                "南风", "南西南风", "西南风", "西西南风",
                "西风", "西西北风", "西北风", "北西北风"
            ];

            int index = ((int)Math.Round(angle / 22.5)) % 16;
            return directions[index];
        }

        public static ImprovedWindInfo From(WeatherData data)
        {
            return new ImprovedWindInfo(data.WindSpeed, data.WindAngle);
        }
    }
}
