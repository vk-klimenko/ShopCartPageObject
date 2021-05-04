using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShopCartPageObject.pages;

namespace ShopCartPageObject.app
{
    public class Application
    {
        private IWebDriver driver;
        private MainShopPage mainPage;
        private ProductPage productPage;
        private CartProductPage cartProduct;

        public Application()
        {
            driver = new ChromeDriver();
            mainPage = new MainShopPage(driver);
            productPage = new ProductPage(driver);
            cartProduct = new CartProductPage(driver);
        }


        internal void AddItemsToCart()
        {
            mainPage.Open();
            mainPage.OpenProduct();
            productPage
                .SubmitAddItem()
                .BackToMainPage();
            mainPage.GetQuantityProduct();
           
            
        }

        internal void RemoveItemsToCart()
        {
            mainPage.OpenCart();
            cartProduct
                .StopCarousel()
                .SubmitRemoveItem();
        }


        public void Quit()
        {
            driver.Quit();
            driver = null;
        }


    }
}
