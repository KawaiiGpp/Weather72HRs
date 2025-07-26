using Weather72HRs.Core.Area.Instance;

namespace Weather72HRs.Core.Area
{
    public class AreaData
    {
        public required Country Country { get; init; }

        public required Province Province { get; init; }

        public required City City { get; init; }

        public required District District { get; init; }
    }
}
