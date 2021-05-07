using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ShopCartPageObject.pages;
using System;

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
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            mainPage = new MainShopPage(driver);
            productPage = new ProductPage(driver);
            cartProduct = new CartProductPage(driver);
        }


        internal void AddItemsToCart()
        {
            mainPage.OpenProduct();
            productPage.SubmitAddItem();
            productPage.BackToMainPage();
        }

        internal void RemoveItemsToCart()
        {
            mainPage.OpenCart();
            cartProduct
                .StopCarousel()
                .SubmitRemoveItem();
            OpenMainPage();
        }

        public void OpenMainPage()
        {
            driver.Url = "http://litecart/";
            
        }
        public void Quit()
        {
            driver.Quit();
            driver = null;
        }


    }
}
