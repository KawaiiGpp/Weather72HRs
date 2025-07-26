using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Deserialization;
using Weather72HRs.Core.Deserialization.Data;

namespace Weather72HRs.Core.Alerts.Instance
{
    public class ColdAlert() : Alert("寒冷", "cold")
    {
        private readonly string[] warmProvinces = ["海南省", "广东省",
            "广西壮族自治区", "福建省", "云南省", "香港", "澳门", "台湾省"];
        private readonly string[] unavailableProvinces = ["黑龙江省",
            "吉林省", "辽宁省", "内蒙古自治区", "新疆维吾尔自治区", "西藏自治区"];
        private readonly int minimumHits = 3;

        public override void Initialize()
        {
            QuickRegister(AlertLevel.Red, "非常寒冷", new(-6, -12, 0, -5), new(2, -2, 6, 2));
            QuickRegister(AlertLevel.Orange, "寒冷", new(0, -5, 4, 0), new(7, 3, 10, 6));
            QuickRegister(AlertLevel.Yellow, "较为寒冷", new(5, 0, 8, 4), new(12, 7, 13, 10));
            QuickRegister(AlertLevel.Blue, "寒凉", new(10, 5, 12, 8), new(15, 12, 16, 13));
        }

        private void QuickRegister(AlertLevel lvl, string cold, Standard regular, Standard warm)
        {
            AlertDescription desc = new()
            {
                Title = $"天气可能或已经变得{cold}。",
                Descriptions =
                    [
                        $"未来24小时内，平均气温不足{regular.AvgT}°C/体感{regular.AvgF}°C",
                        $"未来24小时内，最低气温不足{regular.LowT}°C/体感{regular.LowF}°C",
                        $"",
                        $"对于广东/广西/海南/福建/云南/港澳台：",
                        $"未来24小时内，平均气温不足{warm.AvgT}°C/体感{warm.AvgF}°C",
                        $"未来24小时内，最低气温不足{warm.LowT}°C/体感{warm.LowF}°C"
                    ]
            };

            AlertItem alert = new()
            {
                Level = lvl,
                Category = Category,
                ImageCategory = ImageCategory,
                Predicate = info => CheckLowestTemp(info, regular, warm),
                Description = desc
            };

            Register(alert);
        }

        private bool CheckLowestTemp(HourForecastInfo info, Standard regular, Standard warm)
        {
            string province = info.Location.Path.Split(',')[2];
            if (unavailableProvinces.Contains(province)) return false;

            Standard standard = warmProvinces.Contains(province) ? warm : regular;
            List<HourForecastData> datas = info.Take(24);

            bool lowest = datas.Count(data => data.Temperature <= standard.LowT ||
                data.FeelsLikeImproved <= standard.LowF) >= minimumHits;
            bool average = datas.Select(data => data.Temperature).Average() <= standard.AvgT ||
                datas.Select(data => data.FeelsLikeImproved).Average() <= standard.AvgF;

            return lowest || average;
        }

        private readonly struct Standard(int lowT, int lowF, int avgT, int avgF)
        {
            public readonly int LowT = lowT;
            public readonly int LowF = lowF;
            public readonly int AvgT = avgT;
            public readonly int AvgF = avgF;
        }
    }
}
