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
    internal class ProductPage : Page
    {
        
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        internal IWebElement BtnAddToCart;
        [FindsBy(How = How.Name, Using = "options[Size]")]
        internal IWebElement DropDown;

       
        /// <summary>
        /// Back to home page
        /// </summary>
        /// <returns></returns>
        internal void BackToMainPage()
        {
            driver.Url = baseUrl;
        }


        /// <summary>
        /// Add item to cart shop
        /// </summary>
        /// <returns></returns>
        internal ProductPage SubmitAddItem()
        {
            if (driver.FindElements(By.Name("options[Size]")).Count > 0)
            {
                new SelectElement(DropDown).SelectByIndex(rnd.Next(1, 4));
            }
            BtnAddToCart.Click();
            return this;
        }

       
    }
}
