using Newtonsoft.Json.Linq;
using Weather72HRs.Core.Deserialization.Data;
using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Deserialization
{
    public class WeatherInfo
    {
        public JObject Json { get; }
        public int InternalStatusCode { get; }
        public LocationData Location { get; }
        public DateTime LastUpdate { get; }

        public WeatherInfo(string rawJson)
        {
            Json = JObject.Parse(rawJson);
            InternalStatusCode = GetValue<int>("status");
            Location = GetObject<LocationData>("result.location");
            LastUpdate = DateTime.Parse(GetValue<string>("result.last_update"));
        }

        public JToken? Get(string path)
        {
            string[] pathArray = path.Split('.');
            JToken? temp = Json;

            foreach (string s in pathArray)
            {
                if (temp is JArray array
                    && int.TryParse(s, out int index))
                {
                    if (index < 0 || index >= array.Count)
                        return null;
                    temp = array[index];
                }
                else
                {
                    JToken? next = temp[s];
                    if (next == null) return null;
                    temp = next;
                }
            }

            return temp;
        }

        public T GetValue<T>(string path)
        {
            return GetConverted(path, token => token.Value<T>());
        }

        public T GetObject<T>(string path)
        {
            return GetConverted(path, token => token.ToObject<T>());
        }

        private T GetConverted<T>(string path, Func<JToken, T?> func)
        {
            JToken? token = Get(path);
            Validate.NotNull(token, $"JToken from {path} not found.");

            T? result = func.Invoke(token!);
            Validate.NotNull(result, $"Failed converting JToken from {path}.");

            return result!;
        }
    }
}
