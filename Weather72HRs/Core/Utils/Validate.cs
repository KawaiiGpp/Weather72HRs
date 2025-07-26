namespace Weather72HRs.Core.Utils
{
    public static class Validate
    {
        public static void Ensure(bool condition,
            string message = "Unexpected operation.")
        {
            if (condition) return;
            throw new InvalidOperationException(message);
        }

        public static void InRange<T>(T value, T min, T max,
            string message = "Value is out of range.") where T : IComparable<T>
        {
            if (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0) return;
            throw new InvalidOperationException(message);
        }

        public static void NotNull(object? o,
            string message = "Value cannot be null.")
        {
            if (o != null) return;
            throw new InvalidOperationException(message);
        }

        public static T RequiresNotNull<T>(T? o,
            string message = "Value required is currently null.")
        {
            if (o != null) return o;
            throw new InvalidOperationException(message);
        }

        public static void Contains<T>(IEnumerable<T> enumerable, T element,
            string message = "Collection doesn't contain the expected element.")
        {
            Ensure(enumerable.Contains(element), message);
        }

        public static void NotContains<T>(IEnumerable<T> enumerable, T element,
            string message = "Element is already present in the collection.")
        {
            Ensure(!enumerable.Contains(element), message);
        }

        public static bool IsDefault<T>(T? value)
        {
            return EqualityComparer<T>.Default.Equals(value, default);
        }
    }
}
