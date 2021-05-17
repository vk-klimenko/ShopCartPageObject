﻿using NUnit.Framework;
using ShopCartPageObject.data;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class LinksOpenNewWindowsTests:TestBase
    {
        /*
         * Задание 14. Проверьте, что ссылки открываются в новом окне
         * Сделайте сценарий, который проверяет, что ссылки на странице редактирования страны открываются в новом окне.
         * Сценарий должен состоять из следующих частей:
         * 1) зайти в админку
         * 2) открыть пункт меню Countries (или страницу http://localhost/litecart/admin/?app=countries&doc=countries)
         * 3) открыть на редактирование какую-нибудь страну или начать создание новой
         * 4) возле некоторых полей есть ссылки с иконкой в виде квадратика со стрелкой -- они ведут на внешние страницы 
         * и открываются в новом окне, именно это и нужно проверить.
         * Конечно, можно просто убедиться в том, что у ссылки есть атрибут target="_blank". 
         * Но в этом упражнении требуется именно кликнуть по ссылке, чтобы она открылась в новом окне, потом переключиться в новое окно, 
         * закрыть его, вернуться обратно, и повторить эти действия для всех таких ссылок.
         */
        [Test]
        public void CanOpenLinkInNewWindow()
        {
            CountryData country = new CountryData("RU");
            app.OpenLinkInNewWindow(country);
        }
    }
}
