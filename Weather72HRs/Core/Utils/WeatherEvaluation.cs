namespace Weather72HRs.Core.Utils
{
    public static class WeatherEvaluation
    {
        public static string EvaluateFeel(double temp, double feel)
        {
            double difference = temp - feel;

            bool summer = temp >= 24;
            char cold = summer ? '凉' : '冷';
            char hot = summer ? '热' : '暖';

            return difference switch
            {
                <= -6 => $"体感比实际{cold}得多",
                <= -4 => $"体感明显更{cold}",
                <= -1 => $"体感稍{cold}一些",
                <= 1 => $"体感和实际相近",
                <= 4 => $"体感稍{hot}一些",
                <= 6 => $"体感明显更{hot}",
                _ => $"体感比实际{hot}得多"
            };
        }

        public static string EvaluateHumidity(int humidity)
        {
            return humidity switch
            {
                <= 20 => "非常干燥",
                <= 40 => "干燥",
                <= 50 => "干爽",
                <= 60 => "适中",
                <= 75 => "湿润",
                <= 85 => "潮湿",
                _ => "非常潮湿"
            };
        }

        public static int EvaluateWildFireScore(double temp, double prec, int rh, int wind)
        {
            EvaluateWildFireScore(temp, prec, rh, wind,
                out int tempScore, out int precScore, out int rhScore, out int windScore);
            return tempScore + precScore + rhScore + windScore;
        }

        public static void EvaluateWildFireScore(double temp, double prec, int rh, int wind,
            out int tempScore, out int precScore, out int rhScore, out int windScore)
        {
            tempScore = 0;
            precScore = 0;
            rhScore = 0;
            windScore = 0;

            if (prec > 3) return;
            else if (prec == 0) precScore += 1;

            if (temp >= 36) tempScore += 1;

            if (rh < 26) rhScore += 5;
            else if (rh < 34) rhScore += 4;
            else if (rh < 42) rhScore += 3;
            else if (rh < 50) rhScore += 1;

            if (rh < 45 && prec == 0)
            {
                if (wind >= 4) windScore += 2;
                else if (wind >= 2) windScore += 1;
            }
        }
    }
}
