using Weather72HRs.Core.Area.Base;

namespace Weather72HRs.Core.Area.Instance
{
    public class Province(string name) : Area<City>(name);
}
