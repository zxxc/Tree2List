using AutoFixture;

namespace Tree2List.Tests
{
    public class TestsBase
    {
        protected Fixture Fixture;

        public TestsBase()
        {
            Fixture = new Fixture();
        }
    }
}
