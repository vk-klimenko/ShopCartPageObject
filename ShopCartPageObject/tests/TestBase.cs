using NUnit.Framework;
using ShopCartPageObject.app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
