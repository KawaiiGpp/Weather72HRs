using Weather72HRs.Core.Area.Base;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Area.Instance
{
    public class Country : Area<Province>
    {
        public Country(string name) : base(name)
        {
            string fullName = $"{Name}_areacode_map.txt";
            using StreamReader reader = EmbeddedResources.Texts.GetTextReader(fullName);

            while (true)
            {
                string? line = reader.ReadLine();
                if (line == null) break;

                string[] array = line.Split('=');
                Validate.Ensure(array.Length == 4, $"Failed parsing line: {line}");

                Province province = GetOrCreate(array[1], name => new(name));
                City city = province.GetOrCreate(array[2], name => new(name));
                city.RegisterIfAbsent(new(array[3], array[0]));
            }
        }

        public static readonly Country China = new("china");
    }
}
