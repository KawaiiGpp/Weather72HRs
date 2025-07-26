using Weather72HRs.Core.Area.Base;

namespace Weather72HRs.Core.Area.Instance
{
    public class District(string name, string areaCode) : NamableArea(name)
    {
        public string AreaCode { get; } = areaCode;

        public override bool ApplyAdditionalCompare(NamableArea that)
        {
            return AreaCode == ((District)that).AreaCode;
        }

        public override int GetAdditionalHashCode()
        {
            return HashCode.Combine(AreaCode);
        }
    }
}
