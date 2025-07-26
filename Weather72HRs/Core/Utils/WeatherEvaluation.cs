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
            int score = 0;

            if (rh <= 30) score += 4;
            else if (rh <= 40) score += 3;
            else if (rh <= 50) score += 2;

            if (wind >= 5) score += 2;
            else if (wind >= 3) score += 1;

            if (prec == 0) score += 1;
            if (temp >= 37) score += 1;

            return score;
        }
    }
}
