using NUnit.Framework;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class CartShopTests:TestBase
    {
        [Test]
        public void CanAddRemoveItems()
        {
            app.OpenMainPage();
            for (int i = 0; i < 3; i++)
            {
                app.AddItemsToCart();
            }

            app.RemoveItemsToCart();
        }
    }
}
