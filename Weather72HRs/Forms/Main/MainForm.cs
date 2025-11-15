using Weather72HRs.Core.Area;
using Weather72HRs.Core.Area.Instance;
using Weather72HRs.Core.Deserialization;
using Weather72HRs.Core.Deserialization.Data;
using Weather72HRs.Core.Utils;
using Weather72HRs.Core.Web;
using Weather72HRs.Forms.AlertList;
using Weather72HRs.Forms.AreaSelector;
using Weather72HRs.Forms.Detail;
using static Weather72HRs.Core.Utils.Validate;
using static System.Windows.Forms.ListView;

namespace Weather72HRs
{
    public partial class MainForm : Form
    {
        private readonly Country country;
        private readonly WeatherClient realtimeClient;
        private readonly WeatherClient hourForecastClient;

        private RealtimeInfo? realtimeInfoCache;
        private HourForecastInfo? hourForecastInfoCache;
        private AreaData? areaCache;

        public MainForm(Country country, string token)
        {
            InitializeComponent();

            realtimeClient = WeatherClient.NewRealtimeClient(token);
            hourForecastClient = WeatherClient.NewHourForecastClient(token);
            this.country = country;

            btnAreaSelect.Select();
        }

        private async Task RequestRealtimeInfo(string areaCode)
        {
            WeatherResponse response = await realtimeClient.Get(areaCode);
            string? content = ToolKit.CheckResponse(response, "实时天气数据");
            if (content != null) realtimeInfoCache = new(content);
        }

        private async Task RequestHourForecastInfo(string areaCode)
        {
            WeatherResponse response = await hourForecastClient.Get(areaCode);
            string? content = ToolKit.CheckResponse(response, "逐小时预报");
            if (content != null) hourForecastInfoCache = new(content);
        }

        private void LoadRealtimeGroup()
        {
            RealtimeInfo info = realtimeInfoCache ?? RealtimeInfo.Demo;

            ShowRealtimeInfo(info.Data);
            ToolKit.SetGroupTitle(gbRealtime, "直击现状", info);
        }

        private void LoadHourForecastGroup()
        {
            HourForecastInfo info = hourForecastInfoCache ?? HourForecastInfo.Demo;

            ShowHourForecastInfo(info);
            ToolKit.SetGroupTitle(gbForecast, "展望未来", info);
        }

        private void ShowRealtimeInfo(RealtimeData data)
        {
            {
                lblRealtimeTitle.Text = data.Text;
                lblRealtimeTemp.Text = $"{data.Temperature}°C";
                pbRealtimeIcon.Image = EmbeddedResources.WeatherIcons.GetImage($"{data.Code}.png");
            } // Summary
            {
                double feel = data.FeelsLikeImproved;
                double temp = data.Temperature;

                lblFeelValue.BackColor = ColorRange.Temperature.Get(feel);
                lblFeelValue.ForeColor = ColorUtils.GetFore(lblFeelValue.BackColor);

                lblFeelDesc.Text = WeatherEvaluation.EvaluateFeel(feel, temp);
                lblFeelValue.Text = $"{feel:0.#}°C";
            } // Feel
            {
                int humidity = data.RelativeHumidity;

                lblHumidityValue.BackColor = ColorRange.Humidity.Get(humidity);
                lblHumidityValue.ForeColor = ColorUtils.GetFore(lblHumidityValue.BackColor);

                lblHumidityDesc.Text = $"当前{WeatherEvaluation.EvaluateHumidity(humidity)}";
                lblHumidityValue.Text = $"{humidity}%";
            } // Humidity
            {
                double speed = data.WindSpeed;
                ImprovedWindInfo wind = data.ImprovedWindInfo;

                lblWindValue.BackColor = ColorRange.WindSpeed.Get(speed);
                lblWindValue.ForeColor = ColorUtils.GetFore(lblWindValue.BackColor);

                lblWindDesc.Text = $"{wind.WindDirection} {wind.WindLevelAsString}";
                lblWindValue.Text = $"{speed:0.#}m/s";
            } // Wind
        }

        private void ShowHourForecastInfo(HourForecastInfo info)
        {
            List<HourForecastData> datas = info.Datas;

            lvForecast.Items.Clear();
            imglForecast.Images.Clear();

            foreach (HourForecastData data in datas)
            {
                Image image = EmbeddedResources.WeatherIcons.GetImage($"{data.Code}.png");
                imglForecast.Images.Add(image);

                ImprovedWindInfo wind = data.ImprovedWindInfo;
                string time = DateTime.Parse(data.DataTime).ToString("MM/dd HH:mm");
                ListViewItem item = new(time, lvForecast.Items.Count);

                item.SubItems.Add($"{data.Temperature}°C");
                item.SubItems.Add($"{data.FeelsLikeImproved:0.#}°C*");
                item.SubItems.Add($"{data.RelativeHumidity}%");
                item.SubItems.Add(wind.WindDirection);
                item.SubItems.Add(wind.WindLevelAsString);

                lvForecast.Items.Add(item);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                await RefreshRealtimeInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"刷新实时数据时捕获到异常。\n{ex.Message}", "错误");
            }
        }

        private async void btnRefreshFc_Click(object sender, EventArgs e)
        {
            try
            {
                await RefreshHourForecastInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"刷新预报数据时捕获到异常。\n{ex.Message}", "错误");
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (realtimeInfoCache != null)
                    DetailForm.FromCache(realtimeInfoCache).ShowDialog();
                else MessageBox.Show("目前未加载任何天气数据。", "错误");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"展示实时天气详情时捕获到异常。\n{ex.Message}", "错误");
            }
        }

        private void btnDetailsFc_Click(object sender, EventArgs e)
        {
            try
            {
                if (hourForecastInfoCache == null)
                {
                    MessageBox.Show("目前未加载任何天气数据。", "错误");
                    return;
                }

                SelectedListViewItemCollection selected = lvForecast.SelectedItems;
                if (selected.Count == 0)
                {
                    MessageBox.Show("请先选中想要查询的小时预报。", "错误");
                    return;
                }

                HourForecastData data = hourForecastInfoCache.Datas[selected[0].Index];
                DetailForm.FromHourData(data).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"展示小时预报详情时捕获到异常。\n{ex.Message}", "错误");
            }
        }

        private async void btnAreaSelect_Click(object sender, EventArgs e)
        {
            try
            {
                AreaSelectorForm form = new(country);
                form.ShowDialog();
                if (!form.AreaSelectedProperly) return;

                areaCache = new AreaData
                {
                    Country = country,
                    Province = RequiresNotNull(form.SelectedProvince),
                    City = RequiresNotNull(form.SelectedCity),
                    District = RequiresNotNull(form.SelectedDistrict)
                };

                string province = areaCache.Province.Name;
                string city = areaCache.City.Name;
                string district = areaCache.District.Name;
                Text = $"天气72小时速报：{province}/{city}/{district}";

                await RefreshRealtimeInfo();
                await RefreshHourForecastInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"选择城市时捕获到异常。\n{ex.Message}", "错误");
            }
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            try
            {
                if (hourForecastInfoCache != null)
                    new AlertListForm(hourForecastInfoCache).ShowDialog();
                else MessageBox.Show("目前未加载任何天气数据。", "错误");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"展示天气提示时捕获到异常。\n{ex.Message}", "错误");
            }
        }

        private async Task RefreshRealtimeInfo()
        {
            if (areaCache != null)
            {
                await RequestRealtimeInfo(areaCache.District.AreaCode);
                LoadRealtimeGroup();
            }
            else MessageBox.Show("指定位置信息后才能加载天气数据。", "错误");
        }

        private async Task RefreshHourForecastInfo()
        {
            if (areaCache != null)
            {
                await RequestHourForecastInfo(areaCache.District.AreaCode);
                LoadHourForecastGroup();
            }
            else MessageBox.Show("指定位置信息后才能加载逐小时预报。", "错误");
        }

        private static class ToolKit
        {
            public static string? CheckResponse(WeatherResponse response, string name)
            {
                string? content = response.RawJson;
                Exception? exception = response.ExceptionCaught;

                if (exception != null)
                {
                    MessageBox.Show($"拉取{name}时发生异常：\n" +
                        $"{exception.Message}\n" +
                        "信息拉取失败");
                    return null;
                }

                if (content == null)
                {
                    MessageBox.Show($"拉取{name}时内容为空。\n" +
                        $"如有需要，请保存截图并联系开发者。",
                        "信息拉取失败");
                    return null;
                }

                return content;
            }

            public static void SetGroupTitle(GroupBox groupBox, string originalTitle, WeatherInfo info)
            {
                groupBox.Text = $"{originalTitle} (更新时间 {info.LastUpdate:yyyy/MM/dd HH:mm})";
            }
        }
    }
}
