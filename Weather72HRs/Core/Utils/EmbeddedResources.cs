using System.Reflection;

namespace Weather72HRs.Core.Utils
{
    public partial class EmbeddedResources(string folder)
    {
        private string GetFullPath(string path)
        {
            return $"Weather72HRs.Resources.{folder}.{path}";
        }

        public Stream GetStream(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream? stream = assembly.GetManifestResourceStream(GetFullPath(path));
            Validate.NotNull(stream, $"Nothing found from {path}");
            return stream!;
        }

        public Image GetImage(string path)
        {
            return new Bitmap(Image.FromStream(GetStream(path)));
        }

        public string GetText(string path)
        {
            using StreamReader reader = GetTextReader(path);
            return reader.ReadToEnd();
        }

        public StreamReader GetTextReader(string path)
        {
            return new(GetStream(path));
        }
    }

    public partial class EmbeddedResources
    {
        public static readonly EmbeddedResources Alerts = new("Alerts");

        public static readonly EmbeddedResources Texts = new("Texts");

        public static readonly EmbeddedResources WeatherIcons = new("WeatherIcons");
    }
}
