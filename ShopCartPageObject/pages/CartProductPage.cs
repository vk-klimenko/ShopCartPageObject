using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class CartProductPage:Page
    {
        public CartProductPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-checkout-cart li.shortcut")]
        IWebElement ProductCarousel;
        
        /// <summary>
        /// Stop product carousel
        /// </summary>
        /// <returns></returns>
        internal CartProductPage StopCarousel()
        {
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
        }
    }
}
