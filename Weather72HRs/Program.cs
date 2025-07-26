using Weather72HRs.Core.Area.Instance;

namespace Weather72HRs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            string? token = Environment.GetEnvironmentVariable("WEATHER_TOKEN");
            if (token != null) Application.Run(new MainForm(Country.China, token));
            else MessageBox.Show("环境变量 WEATHER_TOKEN 未正确配置。", "错误");
        }
    }
}