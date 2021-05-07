using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace ShopCartPageObject.pages
{
    internal class CartProductPage:Page
    {
        private string textPresentFound = "There are no items in your cart.";
        public CartProductPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-checkout-cart li.shortcut")]
        IWebElement ProductCarousel;
        [FindsBy(How = How.CssSelector, Using = "#box-checkout-cart li.shortcut")]
        IList<IWebElement> ProductCarousels;

        [FindsBy(How = How.CssSelector, Using = "#checkout-cart-wrapper em")]
        IWebElement TextPresent;
        
        /// <summary>
        /// Stop product carousel
        /// </summary>
        /// <returns></returns>
        internal CartProductPage StopCarousel()
        {
            if (ProductCarousels.Count > 0)
                ProductCarousel.Click();
            return this;
        }

        /// <summary>
        /// Remove product
        /// </summary>
        internal void SubmitRemoveItem()
        {
            IWebElement btnRemoveItem;
            while (driver.FindElements(By.Name("remove_cart_item")).Count() != 0)
            {
                btnRemoveItem = driver.FindElement(By.Name("remove_cart_item"));
                driver.FindElement(By.Name("remove_cart_item")).Click();
                wait.Until(ExpectedConditions.StalenessOf(btnRemoveItem));
            }
            wait.Until(ExpectedConditions.TextToBePresentInElement(TextPresent, textPresentFound));
        }
    }
}
