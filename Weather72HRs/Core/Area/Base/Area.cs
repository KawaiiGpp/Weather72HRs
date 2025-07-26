using Weather72HRs.Core.Utils;

namespace Weather72HRs.Core.Area.Base
{
    public class Area<C>(string name) : NamableArea(name)
        where C : NamableArea
    {
        public List<C> Children { get; } = [];

        public void Register(C child)
        {
            Validate.NotContains(Children, child, $"Child {child.Name} already registered.");
            Children.Add(child);
        }

        public void RegisterIfAbsent(C child)
        {
            if (Children.Contains(child)) return;
            Register(child);
        }

        public C? Get(string name)
        {
            return Children.FirstOrDefault(c => name == c.Name);
        }

        public C GetOrCreate(string name, Func<string, C> creator)
        {
            C? child = Get(name);
            if (child == null)
            {
                child = creator.Invoke(name);
                Register(child);
            }
            return child;
        }

        public override bool ApplyAdditionalCompare(NamableArea that)
        {
            return Children.SequenceEqual(((Area<C>)that).Children);
        }

        public override int GetAdditionalHashCode()
        {
            return HashCode.Combine(Children);
        }
    }
}
