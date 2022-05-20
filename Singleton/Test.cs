using Xunit;

namespace SingletonPattern
{
    public class Tests
    {
        [Fact]
        public void IsSingletonTest()
        {
            var db = Singleton.Instance;
            var db2 = Singleton.Instance;
            Assert.True(db2.Equals(db));
        }
    }
}
