
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace ShopCartPageObject.pages
{
    internal class AddNewProductPage: Page
    {
        public AddNewProductPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//li[@id='app-']/a/*[text()='Catalog']")]
        IWebElement CatalogLink;
        internal void OpenCatalog()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//li[@id='app-']/a/*[text()='Catalog']")));
            CatalogLink.Click();
            wait.Until(d => d.FindElement(By.ClassName("button")));
        }

        [FindsBy(How = How.XPath, Using = ".//a[@class='button' and text()=' Add New Product']")]
        internal IWebElement AddNewProductButton;
        [FindsBy(How = How.XPath, Using = ".//ul[@class='index']//a[text()='General']")]
        internal IWebElement GeneralTab;
        [FindsBy(How = How.XPath, Using = ".//ul[@class='index']//a[text()='Information']")]
        internal IWebElement InformationTab;
        [FindsBy(How = How.XPath, Using = ".//ul[@class='index']//a[text()='Prices']")]
        internal IWebElement PricesTab;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-general']//*[text()=' Enabled']")]
        internal IWebElement Status;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-general']//input[@name='name[en]']")]
        internal IWebElement NameInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-general']//input[@name='code']")]
        internal IWebElement CodeInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-general']//input[@name='categories[]' and @value=1]")]
        internal IWebElement Categories;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-general']//input[@name='product_groups[]' and @value='1-3']")]
        internal IWebElement ProductGroups;
        [FindsBy(How = How.XPath, Using = ".//input[@name='new_images[]']")]
        internal IWebElement UploadImages;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//input[@name='keywords']")]
        internal IWebElement KeywordsInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//input[@name='short_description[en]']")]
        internal IWebElement ShortDescriptionInput;
        [FindsBy(How = How.XPath, Using = ".//div[@class='trumbowyg-editor']")]
        internal IWebElement DescriptionInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//input[@name='head_title[en]']")]
        internal IWebElement HeadTitleInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//input[@name='meta_description[en]']")]
        internal IWebElement MetaDescriptionInput;
        [FindsBy(How = How.XPath, Using = ".//table[@id='table-campaigns']//a[@id='add-campaign']")]
        internal IWebElement CampaignsLink;
        [FindsBy(How = How.Name, Using = "prices[USD]")]
        internal IWebElement PriceUSD;
        [FindsBy(How = How.Name, Using = "prices[EUR]")]
        internal IWebElement PriceEUR;

        [FindsBy(How = How.XPath, Using = ".//button[@name='save']")]
        IWebElement SaveButton;
        internal void Save()
        {
            wait.Until(d => d.FindElement(By.ClassName("button-set")));
            SaveButton.Click();
        }

        #region GeneralTabMethods
        internal void QuantityGeneralTab(string value)
        {
            wait.Until(d => d.FindElement(By.Name("quantity"))).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("quantity")));
        }

        internal void QuantityUnitGeneralTab()
        {
            new SelectElement(driver.FindElement(By.Name("quantity_unit_id"))).SelectByValue("1");
        }
        internal void DeliveryStatusGeneralTab()
        {
            new SelectElement(driver.FindElement(By.Name("delivery_status_id"))).SelectByValue("1");
        }
        internal void SoldOutStatusGeneralTab()
        {
            new SelectElement(driver.FindElement(By.Name("sold_out_status_id"))).SelectByValue("1");
        }
        internal void DateValidFrom(string from)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{from}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("date_valid_from")));
        }
        internal void DateValidTo(string to)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{to}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("date_valid_to")));
        }
        #endregion

        #region InformationTabsMethods
        internal void ManufacturerInformationTab()
        {
            new SelectElement(driver.FindElement(By.Name("manufacturer_id"))).SelectByValue("1");
        }
        #endregion
        internal void PurchasePricePricesTab(string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("purchase_price")));
        }
        internal void PurchaseCurrencyPricesTab()
        {
            new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code"))).SelectByValue("USD");
        }

        internal string SetPriceUSDTab()
        {
            string value = Convert.ToString(new Random().Next(1, 500));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("prices[USD]")));
            return value;
        }
        internal string SetPriceEURTab()
        {
            string value = Convert.ToString(new Random().Next(1, 500));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("prices[EUR]")));
            return value;
        }

        internal void CampaignsStartDate(string start)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{start}T09:00', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("campaigns[new_1][start_date]")));
        }
        internal void CampaignsEndDate(string end)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{end}T23:59', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("campaigns[new_1][end_date]")));
        }
        internal void CampaignsPercentage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '15', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("campaigns[new_1][percentage]")));
        }

        internal void CampaignsUSD(string value)
        {
            value = Convert.ToString(Convert.ToInt32(value) - (Convert.ToInt32(value) * 0.15));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("campaigns[new_1][USD]")));
        }

        internal void CampaignsEUR(string value)
        {
            value = Convert.ToString(Convert.ToInt32(value) - (Convert.ToInt32(value) * 0.15));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}', arguments[0].dispatchEvent(new Event('change'))", driver.FindElement(By.Name("campaigns[new_1][EUR]")));
        }

    }
}
