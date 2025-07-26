namespace Weather72HRs.Core.Web
{
    public class WeatherClient : IDisposable
    {
        private readonly string url;
        private readonly HttpClient client;
        private bool disposed;

        public WeatherClient(string url, string token)
        {
            this.url = url;

            client = new();
            client.DefaultRequestHeaders.Add("X-APISpace-Token", token);
            disposed = false;
        }

        public async Task<WeatherResponse> Get(string areaCode)
        {
            ObjectDisposedException.ThrowIf(disposed, this);

            try
            {
                HttpResponseMessage response = await client.GetAsync($"{url}{areaCode}");
                response.EnsureSuccessStatusCode();
                return WeatherResponse.From(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return WeatherResponse.From(ex);
            }
        }

        public void Dispose()
        {
            if (disposed) return;

            client.Dispose();
            disposed = true;
            GC.SuppressFinalize(this);
        }

        public static WeatherClient NewRealtimeClient(string token) =>
            new("https://eolink.o.apispace.com/456456/weather/v001/now?areacode=", token);

        public static WeatherClient NewHourForecastClient(string token) =>
            new("https://eolink.o.apispace.com/456456/weather/v001/hour?hours=72&areacode=", token);
    }
}
