namespace Weather72HRs.Core.Area.Base
{
    public class NamableArea(string name) : IEquatable<NamableArea>
    {
        public string Name { get; } = name;

        public bool Equals(NamableArea? that)
        {
            if (that == null) return false;
            if (ReferenceEquals(this, that)) return true;
            if (GetType() != that.GetType()) return false;
            if (!ApplyAdditionalCompare(that)) return false;
            return Name == that.Name;
        }

        public virtual bool ApplyAdditionalCompare(NamableArea that) => true;

        public virtual int GetAdditionalHashCode() => 0;

        public override bool Equals(object? that)
        {
            return Equals(that as NamableArea);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, GetType(), GetAdditionalHashCode());
        }

        public static bool operator ==(NamableArea? a, NamableArea? b) => Equals(a, b);

        public static bool operator !=(NamableArea? a, NamableArea? b) => !Equals(a, b);
    }
}
