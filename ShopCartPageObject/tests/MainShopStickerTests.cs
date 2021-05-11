﻿using NUnit.Framework;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class MainShopStickerTests : TestBase
    {
        /*
         * Задание 8. Сделайте сценарий, проверяющий наличие стикеров у товаров
         * Сделайте сценарий, проверяющий наличие стикеров у всех товаров в учебном приложении litecart
         * на главной странице. 
         * Стикеры -- это полоски в левом верхнем углу изображения товара, на которых написано New или Sale 
         * или что-нибудь другое. Сценарий должен проверять, что у каждого товара имеется ровно один стикер.
         */

        [Test]
        public void CanAvailabilityStickers()
        {
            app.OpenPage("http://litecart/rubber-ducks-c-1/");
            app.CheckProductsStickers();
        }
    }
}
