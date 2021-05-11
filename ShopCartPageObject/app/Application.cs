using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        }
        public void Quit()
        {
            driver.Quit();
            driver = null;
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

        public void OpenMainPage()
        {
            driver.Url = "http://litecart/";
        }
        public void OpenPage(string url)
        {
            driver.Url = url;
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
            int count = countriesPage.GetCountries().Count;
            for (int i = 0; i < count; i++)
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
    }
}
