using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ShopCartPageObject.data;
using ShopCartPageObject.pages;
using System;
using System.Collections.Generic;

namespace ShopCartPageObject.app
{
    public class Application
    {
        private IWebDriver driver;
        private MainShopPage mainPage;
        private ProductPage productPage;
        private CartProductPage cartProduct;
        private AdminPanelLoginPage adminPanel;
        private AdminPanelMainPage adminMainPanel;
        private CategoriesPage categoriesPage;
        private AdminPanelCountriesPage countriesPage;
        private AdminPanelGeoZonePage geozonePage;
        private CorrectOpenProductPage correctOpen;
        private RegistrationPage registrationPage;
        private AddNewProductPage addProduct;

        public Application()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            mainPage = new MainShopPage(driver);
            productPage = new ProductPage(driver);
            cartProduct = new CartProductPage(driver);
            adminPanel = new AdminPanelLoginPage(driver);
            adminMainPanel = new AdminPanelMainPage(driver);
            categoriesPage = new CategoriesPage(driver);
            countriesPage = new AdminPanelCountriesPage(driver);
            geozonePage = new AdminPanelGeoZonePage(driver);
            correctOpen = new CorrectOpenProductPage(driver);
            registrationPage = new RegistrationPage(driver);
            addProduct = new AddNewProductPage(driver);
        }
        public void Quit()
        {
            driver.Quit();
            driver = null;
        }

        public void OpenMainPage()
        {
            driver.Url = "http://litecart/";
        }
        public void OpenPage(string url)
        {
            driver.Url = url;
        }


        /// <summary>
        /// Добавить товары в корзину
        /// </summary>
        public void AddItemsToCart()
        {
            mainPage.OpenProduct();
            productPage.SubmitAddItem();
            productPage.BackToMainPage();
        }

        /// <summary>
        /// Удалить товары из корзины
        /// </summary>
        public void RemoveItemsToCart()
        {
            mainPage.OpenCart();
            cartProduct
                .StopCarousel()
                .SubmitRemoveItem();
            OpenMainPage();
        }

        
        /// <summary>
        /// Авторизация в админ панель
        /// </summary>
        /// <param name="name">логин</param>
        /// <param name="pass">пароль</param>
        /// <param name="flag">чекбокс "запомнить"</param>
        public void AdminLoginPanel(string name, string pass, bool flag = false)
        {
            adminPanel.OpenAdminPage();
            adminPanel
                .EntryUserName(name)
                .EntryUserPass(pass)
                .SubmitLogin();
        }

        /// <summary>
        /// Прокликивание левого меню
        /// </summary>
        public void SelectLeftMenu()
        {
            for (int i = 0; i < adminMainPanel.GetSections().Count; i++)
            {
                adminMainPanel.GetSections()[i].Click();
                Assert.IsTrue(adminMainPanel.IsH1Present());

                if(adminMainPanel.AreSubSectionsPresent())
                {
                    for (int j = 0; j < adminMainPanel.GetSubSections().Count; j++)
                    {
                        adminMainPanel.GetSubSections()[j].Click();
                        Assert.IsTrue(adminMainPanel.IsH1Present());
                        adminMainPanel.GetSubSections();
                    }
                }
                adminMainPanel.GetSections();
            }
        }

        /// <summary>
        /// Проверка наличия стикеров на товарах
        /// </summary>
        public void CheckProductsStickers()
        {
            for (int i = 0; i < categoriesPage.GetCategoriesProducts().Count; i++)
            {
                categoriesPage.IsStickerPresent(i);
            }
        }

        /// <summary>
        /// Проверка сортировки стран
        /// </summary>
        public void CheckCountriesSort()
        {
            countriesPage.OpenAdminCountriesPage();
            
            for (int i = 0; i < countriesPage.GetCountries().Count; i++)
            {
                countriesPage.Countries.Add(countriesPage.GetCountryName(countriesPage.GetCountries()[i]));
                if(countriesPage.GetZoneCount() > 0)
                {
                    OpenPage(countriesPage.GetCountryUrl(countriesPage.GetCountries()[i]));

                    for (int j = 0; j < countriesPage.GetCountriesZone().Count; j++)
                    {
                        countriesPage.ByZones.Add(countriesPage.GetCountriesZone()[j].GetAttribute("textContent").Trim());
                    }

                    List<string> ByZonesSort = countriesPage.ByZones;
                    Assert.IsTrue(countriesPage.IsCountriesZoneSort(ByZonesSort));
                }
            }
            List<string> countriesSort = countriesPage.Countries;
            Assert.IsTrue(countriesPage.IsCountriesSort(countriesSort));
        }

        /// <summary>
        /// Проверка сортировки гео зон
        /// </summary>
        public void CheckGeoZoneSort()
        {
            geozonePage.OpenPageZone();
            for (int i = 0; i < geozonePage.GeoZones.Count; i++)
            {
                string url = geozonePage.GetUrlZone(geozonePage.GeoZones[i]);
                
                OpenPage(url);

                foreach(IWebElement el in geozonePage.OptionSelect)
                {
                    geozonePage.ZoneCountry.Add(el.GetAttribute("textContent").Trim());
                }

                geozonePage.ZoneCountrySort = geozonePage.ZoneCountry;
                geozonePage.ZoneCountrySort.Sort();

                Assert.IsTrue(geozonePage.IsGeoZoneSort());

                geozonePage.OpenPageZone();

                geozonePage.ZoneCountry.Clear();
                geozonePage.ZoneCountrySort.Clear();
            }
        }

        /// <summary>
        /// Проверка товара на главной странице и на странице товара
        /// </summary>
        public void CheckCorrectProduct()
        {
            Dictionary<string, string> ProductMainPage = new Dictionary<string, string>();
            Dictionary<string, string> ProductCardPage = new Dictionary<string, string>();
            
            // Данные товара с главной страницы.
            ProductMainPage.Add("name", correctOpen.Name.Text);
            ProductMainPage.Add("priceRegular", correctOpen.RegularPrice.Text);
            ProductMainPage.Add("priceCampaign", correctOpen.CampaignPrice.Text);

            ProductMainPage.Add("priceColorRegular", correctOpen.GetCssValue_Color(correctOpen.RegularPrice));
            ProductMainPage.Add("priceColorCampaign", correctOpen.GetCssValue_Color(correctOpen.CampaignPrice));

            ProductMainPage.Add("priceLineThrough", correctOpen.GetCssValue_LineThrough(correctOpen.RegularPrice));
            
            ProductMainPage.Add("priceBold", correctOpen.GetCssValue_FontWeighth(correctOpen.CampaignPrice));
            ProductMainPage.Add("priceFontSizeCampaign", correctOpen.GetCssValue_FontSize(correctOpen.CampaignPrice));
            ProductMainPage.Add("priceFontSizeRegular", correctOpen.GetCssValue_FontSize(correctOpen.RegularPrice));

            // Данные с страницы карточки товара.
            correctOpen.LinkCard.Click();
            ProductCardPage.Add("name", correctOpen.NameCard.Text);
            ProductCardPage.Add("priceRegular",correctOpen.RegularPriceCard.Text);
            ProductCardPage.Add("priceCampaign", correctOpen.CampaignPriceCard.Text);
            ProductCardPage.Add("priceColorRegular", correctOpen.GetCssValue_Color(correctOpen.RegularPriceCard));
            ProductCardPage.Add("priceFontSizeCampaign", correctOpen.GetCssValue_FontSize(correctOpen.CampaignPriceCard));
            ProductCardPage.Add("priceFontSizeRegular", correctOpen.GetCssValue_FontSize(correctOpen.RegularPriceCard));

            // а) проверка на главной странице и на странице товара совпадает текст названия товара 
            Assert.IsTrue(ProductMainPage["name"] == ProductCardPage["name"]);
            // б) на главной странице и на странице товара совпадают цены (обычная и акционная) 
            Assert.IsTrue(
                        ProductMainPage["priceRegular"] == ProductCardPage["priceRegular"] && 
                        ProductMainPage["priceCampaign"] == ProductCardPage["priceCampaign"]
                        );
            // в) обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой, у которого в RGBa представлении одинаковые значения для каналов R, G и B) 
            Assert.IsTrue(
                        ProductMainPage["priceLineThrough"] == "line-through" &&
                        ProductMainPage["priceColorRegular"].Split(',')[0].Trim() == ProductMainPage["priceColorRegular"].Split(',')[1].Trim() &&
                        ProductMainPage["priceColorRegular"].Split(',')[1].Trim() == ProductMainPage["priceColorRegular"].Split(',')[2].Trim()
                        );
            // г) акционная жирная и красная (можно считать, что "красный" цвет это такой, у которого в RGBa представлении каналы G и B имеют нулевые значения) 
            Assert.IsTrue(
                        ProductMainPage["priceBold"] == "bold" || ProductMainPage["priceBold"] == "700" &&
                        ProductMainPage["priceColorCampaign"].Split(',')[1].Trim() == ProductMainPage["priceColorCampaign"].Split(',')[2].Trim()
                        );
            // д) акционная цена крупнее, чем обычная (это тоже надо проверить на каждой странице независимо) 
            Assert.IsTrue(Convert.ToDouble(ProductMainPage["priceFontSizeCampaign"]) > Convert.ToDouble(ProductMainPage["priceFontSizeRegular"]));
            Assert.IsTrue(Convert.ToDouble(ProductCardPage["priceFontSizeCampaign"]) > Convert.ToDouble(ProductCardPage["priceFontSizeRegular"]));
        }

        /// <summary>
        /// Регистрация нового покупателя
        /// </summary>
        /// <param name="customer">Данные покупателя</param>
        public void RegisterNewCustomer(CustomersData customer)
        {
            registrationPage.OpenPage();
            registrationPage.FirstNameInput.SendKeys(customer.Firstname);
            registrationPage.LastNameInput.SendKeys(customer.Lastname);
            registrationPage.AddressInput.SendKeys(customer.Address);
            registrationPage.PostcodeInput.SendKeys(customer.Postcode);
            registrationPage.CityInput.SendKeys(customer.City);
            registrationPage.SelectCountry(customer.Country);
            registrationPage.SelectZone(customer.Zone);
            registrationPage.EmailInput.SendKeys(customer.Email);
            registrationPage.PhoneInput.SendKeys(customer.Phone);
            registrationPage.PasswordInput.SendKeys(customer.Password);
            registrationPage.ConfirmedPasswordInput.SendKeys(customer.Password);
            registrationPage.CreateAccountButton.Click();

            registrationPage.Logout();

            registrationPage
                .AuthCustomer(customer.Email, customer.Password)
                .LoginButton.Click();

            registrationPage.Logout();

        }

        /// <summary>
        /// Добавление товара
        /// </summary>
        public void AddNewProduct(ProductsData product)
        {
            adminPanel.OpenAdminPage();
            adminPanel
                .EntryUserName("admin")
                .EntryUserPass("admin")
                .SubmitLogin();

            addProduct.OpenCatalog();
            addProduct.AddNewProductButton.Click();

            addProduct.Status.Click();
            addProduct.NameInput.SendKeys(product.Name);
            addProduct.CodeInput.SendKeys(product.Code);
            addProduct.Categories.Click();
            addProduct.ProductGroups.Click();
            addProduct.QuantityGeneralTab(product.Quantity);
            addProduct.QuantityUnitGeneralTab();
            addProduct.DeliveryStatusGeneralTab();
            addProduct.SoldOutStatusGeneralTab();
            addProduct.UploadImages.SendKeys(product.ImagePath);
            addProduct.DateValidFrom(product.DateFrom);
            addProduct.DateValidTo(product.DateTo);

            addProduct.InformationTab.Click();
            addProduct.ManufacturerInformationTab();
            addProduct.KeywordsInput.SendKeys(product.Keywords);
            addProduct.ShortDescriptionInput.SendKeys(product.ShortDescription);
            addProduct.DescriptionInput.SendKeys(product.Description);
            addProduct.HeadTitleInput.SendKeys(product.HeadTitle);
            addProduct.MetaDescriptionInput.SendKeys(product.MetaDescription);

            addProduct.PricesTab.Click();
            addProduct.PurchasePricePricesTab(product.PurchasePrice);
            addProduct.PurchaseCurrencyPricesTab();
            string usd = addProduct.SetPriceUSDTab();
            string eur = addProduct.SetPriceEURTab();
            addProduct.CampaignsLink.Click();
            addProduct.CampaignsStartDate(product.DateFrom);
            addProduct.CampaignsEndDate(product.DateTo);
            addProduct.CampaignsPercentage();
            addProduct.CampaignsUSD(usd);
            addProduct.CampaignsEUR(eur);

            addProduct.Save();


        }

    }
}
