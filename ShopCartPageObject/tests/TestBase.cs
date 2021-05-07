using NUnit.Framework;
using ShopCartPageObject.app;

namespace ShopCartPageObject.tests
{
    public class TestBase
    {
        public Application app;

        [SetUp]
        public void Start()
        {
            app = new Application();
        }
        [TearDown]
        public void Stop()
        {
            app.Quit();
        }
    }
}
