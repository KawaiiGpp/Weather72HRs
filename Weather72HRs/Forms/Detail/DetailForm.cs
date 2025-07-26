using Weather72HRs.Core.Deserialization;
using Weather72HRs.Core.Deserialization.Data;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Forms.Detail
{
    public partial class DetailForm : Form
    {
        private readonly WeatherData data;

        public DetailForm(WeatherData data)
        {
            this.data = data;
            InitializeComponent();
            LoadContent();
            btnClose.Select();
        }

        private void LoadContent()
        {
            DataGridViewRowCollection rows = dgvInfo.Rows;
            ImprovedWindInfo improvedWind = data.ImprovedWindInfo;

            rows.Add("天气状态", $"{data.Text}");
            rows.Add("天气状态码", $"{data.Code}");
            rows.Add("气温", $"{data.Temperature}°C");
            rows.Add("体感温度", $"{data.FeelsLike}°C");
            rows.Add("体感温度(改进)", $"{data.FeelsLikeImproved:0.####}°C");
            rows.Add("湿度", $"{data.RelativeHumidity}%");
            rows.Add("蒲福风级", $"{data.WindLevel}");
            rows.Add("风向", $"{data.WindDirection}");
            rows.Add("风向角度", $"{data.WindAngle}°");
            rows.Add("风速", $"{data.WindSpeed}m/s");
            rows.Add("蒲福风级(改进)", $"{improvedWind.WindLevelAsString}");
            rows.Add("蒲福风级(改进[原始值])", $"{improvedWind.WindLevel}");
            rows.Add("风向(改进)", $"{improvedWind.WindDirection}");
            rows.Add("降雨量", $"{data.Precipitation}mm");
            rows.Add("云量", $"{data.Clouds}%");
            rows.Add("气压", $"{data.Pressure}hPa");

            
            if (data is HourForecastData forecast)
            {
                WeatherEvaluation.EvaluateWildFireScore(forecast.Temperature, 
                    forecast.Precipitation, forecast.RelativeHumidity, forecast.ImprovedWindInfo.WindLevel,
                    out int temp, out int prec, out int rh, out int wind);
                int wildFireScore = temp + prec + rh + wind;

                rows.Add("森林火险值", $"{wildFireScore} (T{temp}+P{prec}+R{rh}+W{wind})");
                rows.Add("数据更新时间", $"{forecast.DataTime}");
            }
            else if (data is RealtimeData realtime)
            {
                rows.Add("降雨量更新时间", $"{realtime.PrecipitationTime}");
                rows.Add("可视距离", $"{realtime.Visibility:#,###}米");
                rows.Add("露点", $"{realtime.DewPoint}°C");
                rows.Add("紫外线指数", $"{realtime.UvIndex}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        public static DetailForm FromCache(RealtimeInfo cache) => new(cache.Data);

        public static DetailForm FromHourData(HourForecastData hourData) => new(hourData);
    }
}
