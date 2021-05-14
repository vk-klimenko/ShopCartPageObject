
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ShopCartPageObject.pages
{
    internal class AddNewProductPage: Page
    {
        public AddNewProductPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//li[@id='app-']/a/*[text()='Catalog']")]
        internal IWebElement CatalogLink;
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
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//textarea[@name='description[en]']")]
        internal IWebElement DescriptionInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//input[@name='head_title[en]']")]
        internal IWebElement HeadTitleInput;
        [FindsBy(How = How.XPath, Using = ".//div[@id='tab-information']//input[@name='meta_description[en]']")]
        internal IWebElement MetaDescriptionInput;
        [FindsBy(How = How.XPath, Using = ".//table[@id='table-campaigns']//a[@id='add-campaign']")]
        internal IWebElement CampaignsLink;
        [FindsBy(How = How.XPath, Using = ".//input[@name='prices[USD]']")]
        internal IWebElement PriceUSD;
        [FindsBy(How = How.XPath, Using = ".//input[@name='prices[EUR]']")]
        internal IWebElement PriceEUR;

        [FindsBy(How = How.XPath, Using = ".//button[@name='save']")]
        internal IWebElement SaveButton;

        internal void QuantityGeneralTab(string value)
        {
            wait.Until(d => d.FindElement(By.Name("quantity"))).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}'", driver.FindElement(By.Name("quantity")));
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
            js.ExecuteScript($"arguments[0].value = '{from}'", driver.FindElement(By.Name("date_valid_from")));
        }
        internal void DateValidTo(string to)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{to}'", driver.FindElement(By.Name("date_valid_to")));
        }
        internal void ManufacturerInformationTab()
        {
            new SelectElement(driver.FindElement(By.Name("manufacturer_id"))).SelectByValue("1");
        }

        internal void PurchasePricePricesTab(string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{value}'", driver.FindElement(By.Name("purchase_price")));
        }
        internal void PurchaseCurrencyPricesTab()
        {
            new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code"))).SelectByValue("USD");
        }
        internal void CampaignsStartDate(string start)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{start}'", driver.FindElement(By.Name("campaigns[new_1][start_date]")));
        }
        internal void CampaignsEndDate(string end)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{end}'", driver.FindElement(By.Name("campaigns[new_1][end_date]")));
        }
        internal void CampaignsPercentage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '15'", driver.FindElement(By.Name("campaigns[new_1][percentage]")));
        }

    }
}
