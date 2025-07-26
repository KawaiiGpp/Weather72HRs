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
            string? content = ToolKit.CheckResponse(response, "ʵʱ��������");
            if (content != null) realtimeInfoCache = new(content);
        }

        private async Task RequestHourForecastInfo(string areaCode)
        {
            WeatherResponse response = await hourForecastClient.Get(areaCode);
            string? content = ToolKit.CheckResponse(response, "��СʱԤ��");
            if (content != null) hourForecastInfoCache = new(content);
        }

        private void LoadRealtimeGroup()
        {
            RealtimeInfo info = realtimeInfoCache ?? RealtimeInfo.Demo;

            ShowRealtimeInfo(info.Data);
            ToolKit.SetGroupTitle(gbRealtime, "ֱ����״", info);
        }

        private void LoadHourForecastGroup()
        {
            HourForecastInfo info = hourForecastInfoCache ?? HourForecastInfo.Demo;

            ShowHourForecastInfo(info);
            ToolKit.SetGroupTitle(gbForecast, "չ��δ��", info);
        }

        private void ShowRealtimeInfo(RealtimeData data)
        {
            {
                lblRealtimeTitle.Text = data.Text;
                lblRealtimeTemp.Text = $"{data.Temperature}��C";
                pbRealtimeIcon.Image = EmbeddedResources.WeatherIcons.GetImage($"{data.Code}.png");
            } // Summary
            {
                double feel = data.FeelsLikeImproved;
                double temp = data.Temperature;

                lblFeelValue.BackColor = ColorRange.Temperature.Get(feel);
                lblFeelValue.ForeColor = ColorUtils.GetFore(lblFeelValue.BackColor);

                lblFeelDesc.Text = WeatherEvaluation.EvaluateFeel(feel, temp);
                lblFeelValue.Text = $"{feel:0.#}��C";
            } // Feel
            {
                int humidity = data.RelativeHumidity;

                lblHumidityValue.BackColor = ColorRange.Humidity.Get(humidity);
                lblHumidityValue.ForeColor = ColorUtils.GetFore(lblHumidityValue.BackColor);

                lblHumidityDesc.Text = $"��ǰ{WeatherEvaluation.EvaluateHumidity(humidity)}";
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

                item.SubItems.Add($"{data.Temperature}��C");
                item.SubItems.Add($"[{data.FeelsLikeImproved:0.#}��C]");
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
                MessageBox.Show($"ˢ��ʵʱ����ʱ�����쳣��\n{ex.Message}", "����");
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
                MessageBox.Show($"ˢ��Ԥ������ʱ�����쳣��\n{ex.Message}", "����");
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (realtimeInfoCache != null)
                    DetailForm.FromCache(realtimeInfoCache).ShowDialog();
                else MessageBox.Show("Ŀǰδ�����κ��������ݡ�", "����");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"չʾʵʱ��������ʱ�����쳣��\n{ex.Message}", "����");
            }
        }

        private void btnDetailsFc_Click(object sender, EventArgs e)
        {
            try
            {
                if (hourForecastInfoCache == null)
                {
                    MessageBox.Show("Ŀǰδ�����κ��������ݡ�", "����");
                    return;
                }

                SelectedListViewItemCollection selected = lvForecast.SelectedItems;
                if (selected.Count == 0)
                {
                    MessageBox.Show("����ѡ����Ҫ��ѯ��СʱԤ����", "����");
                    return;
                }

                HourForecastData data = hourForecastInfoCache.Datas[selected[0].Index];
                DetailForm.FromHourData(data).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"չʾСʱԤ������ʱ�����쳣��\n{ex.Message}", "����");
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
                Text = $"����72Сʱ�ٱ���{province}/{city}/{district}";

                await RefreshRealtimeInfo();
                await RefreshHourForecastInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ѡ�����ʱ�����쳣��\n{ex.Message}", "����");
            }
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            try
            {
                if (hourForecastInfoCache != null)
                    new AlertListForm(hourForecastInfoCache).ShowDialog();
                else MessageBox.Show("Ŀǰδ�����κ��������ݡ�", "����");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"չʾ������ʾʱ�����쳣��\n{ex.Message}", "����");
            }
        }

        private async Task RefreshRealtimeInfo()
        {
            if (areaCache != null)
            {
                await RequestRealtimeInfo(areaCache.District.AreaCode);
                LoadRealtimeGroup();
            }
            else MessageBox.Show("ָ��λ����Ϣ����ܼ����������ݡ�", "����");
        }

        private async Task RefreshHourForecastInfo()
        {
            if (areaCache != null)
            {
                await RequestHourForecastInfo(areaCache.District.AreaCode);
                LoadHourForecastGroup();
            }
            else MessageBox.Show("ָ��λ����Ϣ����ܼ�����СʱԤ����", "����");
        }

        private static class ToolKit
        {
            public static string? CheckResponse(WeatherResponse response, string name)
            {
                string? content = response.RawJson;
                Exception? exception = response.ExceptionCaught;

                if (exception != null)
                {
                    MessageBox.Show($"��ȡ{name}ʱ�����쳣��\n" +
                        $"{exception.Message}\n" +
                        "��Ϣ��ȡʧ��");
                    return null;
                }

                if (content == null)
                {
                    MessageBox.Show($"��ȡ{name}ʱ����Ϊ�ա�\n" +
                        $"������Ҫ���뱣���ͼ����ϵ�����ߡ�",
                        "��Ϣ��ȡʧ��");
                    return null;
                }

                return content;
            }

            public static void SetGroupTitle(GroupBox groupBox, string originalTitle, WeatherInfo info)
            {
                groupBox.Text = $"{originalTitle} (����ʱ�� {info.LastUpdate:yyyy/MM/dd HH:mm})";
            }
        }
    }
}
