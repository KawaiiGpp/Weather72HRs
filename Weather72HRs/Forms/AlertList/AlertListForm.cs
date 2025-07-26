using System.Text;
using Weather72HRs.Core.Alerts;
using Weather72HRs.Core.Alerts.Base;
using Weather72HRs.Core.Deserialization;

namespace Weather72HRs.Forms.AlertList
{
    public partial class AlertListForm : Form
    {
        private readonly List<AlertItem> alerts;

        public AlertListForm(HourForecastInfo info)
        {
            InitializeComponent();
            alerts = AlertMaster.Instance.GetActiveItems(info);

            InitializeAlerts();
        }

        private void InitializeAlerts()
        {
            foreach (AlertItem alert in alerts)
            {
                int index = lvAlertList.Items.Count;
                ListViewItem item = new(alert.DisplayName, index);
                item.SubItems.Add(alert.Description.Title);

                imglAlertList.Images.Add(alert.Image);
                lvAlertList.Items.Add(item);
            }

            int count = alerts.Count;
            if (count > 0) lblTitle.Text = $"目前共{count}条提示生效";
            else lblTitle.Text = "目前暂无提示生效";
        }

        private void lvAlertList_DoubleClick(object sender, EventArgs e)
        {
            if (lvAlertList.SelectedItems.Count == 0) return;

            AlertItem item = alerts[lvAlertList.SelectedItems[0].Index];
            AlertDescription desc = item.Description;
            StringBuilder builder = new();

            builder.Append($"[{item.DisplayName}] {desc.Title}");
            builder.Append('\n');

            foreach (string line in desc.Descriptions)
            {
                builder.Append('\n');
                builder.Append(line);
            }

            MessageBox.Show(builder.ToString(), "详细信息");
        }
    }
}
