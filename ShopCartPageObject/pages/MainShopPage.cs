using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class MainShopPage:Page
    {
        public MainShopPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#cart a.link")]
        internal IWebElement CartLink;
        [FindsBy(How = How.CssSelector, Using = "#box-most-popular li a.link")]
        internal IWebElement ProductFirstItem;
        [FindsBy(How = How.CssSelector, Using = "#cart span.quantity")]
        internal IWebElement ProductQuantity;
        

        /// <summary>
        /// Open main page
        /// </summary>
        /// <returns></returns>
        internal void Open()
        {
            driver.Url = baseUrl;
        }

        /// <summary>
        /// Open cart shop
        /// </summary>
        /// <returns></returns>
        internal void OpenCart()
        {
            driver.Url = CartLink.GetAttribute("href").Trim();
        }


        /// <summary>
        /// Open first product
        /// </summary>
        /// <returns></returns>
        internal void OpenProduct()
        {
            ProductFirstItem.Click();
        }


        internal MainShopPage GetQuantityProduct()
        {
            string value = (int.Parse(ProductQuantity.GetAttribute("textContent")) + 1).ToString();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(dr => ProductQuantity.GetAttribute("textContent").Equals(value));
            return this;
        }
    }
}
