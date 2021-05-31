using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace ShopCartPageObject.pages
{
    internal class MainShopPage:Page
    {
        public MainShopPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#cart a.link")]
        IWebElement CartLink;
        [FindsBy(How = How.CssSelector, Using = "#box-most-popular li a.link")]
        IWebElement ProductFirstItem;
        /// <summary>
        /// Open main page
        /// </summary>
        internal void OpenMainPage()
        {
            driver.Url = "http://litecart/";
        }
        /// <summary>
        /// Open cart shop
        /// </summary>
        /// <returns></returns>
        internal void OpenCart()
        {
            driver.Url = CartLink.GetAttribute("href").Trim();
            wait.Until(ExpectedConditions.TitleIs("Checkout | My Store"));
        }


        /// <summary>
        /// Open first product
        /// </summary>
        /// <returns></returns>
        internal void OpenProduct()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ProductFirstItem));
            ProductFirstItem.Click();
        }


        
    }
}
