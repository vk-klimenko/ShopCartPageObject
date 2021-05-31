using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class CategoriesPage : Page
    {
        public CategoriesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "ul.products")]
        IWebElement Products;
        
        internal IList<IWebElement> GetCategoriesProducts()
        {
            return Products.FindElements(By.TagName("li"));
        }

        internal bool IsStickerPresent(int i)
        {
            try
            {
                Products.FindElements(By.TagName("li"))[i].FindElement(By.CssSelector("div.sticker.sale"));
                Console.Out.WriteLine("Sticker is present");
                return true;
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Sticker is NOT present");
                return false;
            }
        }

    }
}
