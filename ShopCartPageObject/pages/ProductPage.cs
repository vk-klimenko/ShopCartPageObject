using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ShopCartPageObject.pages
{
    internal class ProductPage : Page
    {
        
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        IWebElement BtnAddToCart;
        [FindsBy(How = How.Name, Using = "options[Size]")]
        IWebElement DropDown;
        [FindsBy(How = How.CssSelector, Using = "#cart span.quantity")]
        IWebElement ProductQuantity;

        /// <summary>
        /// Back to home page
        /// </summary>
        /// <returns></returns>
        internal void BackToMainPage()
        {
            driver.Url = baseUrl;
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
        }


        /// <summary>
        /// Add item to cart shop
        /// </summary>
        /// <returns></returns>
        internal void SubmitAddItem()
        {
            int quantity = (int.Parse(ProductQuantity.GetAttribute("textContent")));

            if (driver.FindElements(By.Name("options[Size]")).Count > 0)
            {
                new SelectElement(DropDown).SelectByIndex(1);
            }
            BtnAddToCart.Click();

            wait.Until(driver => GetQuantityValue(quantity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool GetQuantityValue(int value)
        {
            return wait.Until(driver => ProductQuantity.GetAttribute("textContent").Equals((value + 1).ToString()));
        }
    }
}
