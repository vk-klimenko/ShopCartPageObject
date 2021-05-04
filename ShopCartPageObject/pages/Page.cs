using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class Page
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Random rnd;
        protected string baseUrl = "http://litecart/";

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

    }
}
