using Weather72HRs.Core.Deserialization.Data;

namespace Weather72HRs.Core.Utils
{
    public class FeelCalculator
    {
        private double temperature;
        private double windSpeed;
        private double humidity;

        public double Temperature
        {
            get => temperature;
            set => temperature = value;
        }
        public double WindSpeed
        {
            get => windSpeed;
            set => windSpeed = Math.Max(0, value);
        }
        public double Humidity
        {
            get => humidity;
            set => humidity = Math.Clamp(value, 0, 100);
        }

        public FeelCalculator(double temperature, double humidity, double windSpeed)
        {
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
        }

        public double Calculate()
        {
            double steadman = CalculateSteadman();

            if (Temperature <= 10)
                return Math.Min(CalculateWindChill(), steadman);

            //if (Temperature >= 28 && Humidity >= 40)
            //    return Math.Max(CalculateHeatIndex(), steadman);

            return steadman;
        }

        private double CalculateWindChill()
        {
            double windKmh = WindSpeed * 3.6;
            return 13.12 +
                   0.6215 * Temperature -
                   11.37 * Math.Pow(windKmh, 0.16) +
                   0.3965 * Temperature * Math.Pow(windKmh, 0.16);
        }

        //private double CalculateHeatIndex()
        //{
        //    double c1 = -8.78469475556;
        //    double c2 = 1.61139411;
        //    double c3 = 2.33854883889;
        //    double c4 = -0.14611605;
        //    double c5 = -0.012308094;
        //    double c6 = -0.0164248277778;
        //    double c7 = 0.002211732;
        //    double c8 = 0.00072546;
        //    double c9 = -0.000003582;
        //    double result = c1 + c2 * Temperature + c3 * Humidity + c4 * Temperature * Humidity +
        //           c5 * Math.Pow(Temperature, 2) + c6 * Math.Pow(Humidity, 2) +
        //           c7 * Math.Pow(Temperature, 2) * Humidity +
        //           c8 * Temperature * Math.Pow(Humidity, 2) +
        //           c9 * Math.Pow(Temperature, 2) * Math.Pow(Humidity, 2);

        //    double effectiveWind = Math.Min(WindSpeed, 12);
        //    double windCooling = 0.5 * effectiveWind - 0.2 * Math.Pow(effectiveWind, 0.75);
        //    return result - windCooling;
        //}

        private double CalculateSteadman()
        {
            double saturationVaporPressure = 6.105 * Math.Exp(17.27 * Temperature / (237.7 + Temperature));
            double vaporPressure = saturationVaporPressure * (Humidity / 100.0);
            double effectiveWind = Math.Min(WindSpeed, 12);

            return Temperature + 0.348 * vaporPressure - 0.70 * effectiveWind - 4.25;
        }

        public static FeelCalculator From(WeatherData data) =>
             new(data.Temperature, data.RelativeHumidity, data.WindSpeed);
    }
}
