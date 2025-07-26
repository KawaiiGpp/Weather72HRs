using System.Text;

namespace Weather72HRs.Core.Alerts.Base
{
    public class AlertDescription
    {
        public string Title { get; init; } = "未来24-72小时内将触发下列任意一条。";
        public string[] Descriptions { get; init; } = [];

        public override string ToString()
        {
            if (Descriptions.Length > 0)
            {
                StringBuilder builder = new();
                builder.Append(Title);

                foreach (string item in Descriptions)
                {
                    builder.Append(item);
                    builder.Append('\n');
                }

                return builder.ToString();
            }
            else return "标准未定义。";
        }
    }
}
