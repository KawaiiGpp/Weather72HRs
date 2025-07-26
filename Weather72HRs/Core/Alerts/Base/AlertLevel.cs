using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Alerts.Base
{
    public class AlertLevel
    {
        public static readonly AlertLevel Blue = new(0);
        public static readonly AlertLevel Yellow = new(1);
        public static readonly AlertLevel Orange = new(2);
        public static readonly AlertLevel Red = new(3);

        public int ImageIndex { get; }
        public string Color { get; }

        private AlertLevel(int imageIndex)
        {
            Validate.InRange(imageIndex, 0, 3,
                "Alert level index must be between 0 and 3.");

            ImageIndex = imageIndex;
            Color = imageIndex switch
            {
                0 => "蓝色",
                1 => "黄色",
                2 => "橙色",
                3 => "红色",
                _ => throw new InvalidOperationException()
            };
        }
    }
}
