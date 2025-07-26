using Weather72HRs.Core.Area.Base;

namespace Weather72HRs.Core.Area.Instance
{
    public class City(string name) : Area<District>(name)
    {
        public District? GetByCode(string code)
        {
            return Children.FirstOrDefault(c => code == c.AreaCode);
        }
    }
}
