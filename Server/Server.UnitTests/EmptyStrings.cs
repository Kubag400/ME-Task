using System.Collections;

namespace Server.UnitTests
{
    public class EmptyStrings : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "" };
            yield return new object[] { " " };
            yield return new object[] { "  " };
            yield return new object[] { string.Empty };
            yield return new object[] { null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
