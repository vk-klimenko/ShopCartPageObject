using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ShopCartPageObject.pages
{
    internal class Page
    {
        internal IWebDriver driver;
        internal WebDriverWait wait;
        internal Random rnd;
        internal string baseUrl = "http://litecart/";

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

    }
}
