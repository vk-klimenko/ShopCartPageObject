using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class CartShopTests:TestBase
    {
        [Test]
        public void CanAddRemoveItems()
        {
            for (int i = 0; i < 3; i++)
            {
                app.AddItemsToCart();
            }

            app.RemoveItemsToCart();
        }
    }
}
