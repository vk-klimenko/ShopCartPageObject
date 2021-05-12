using NUnit.Framework;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class AdminPanelCountriesGeoZoneTests: TestBase
    {
        /*
         * Задание 9. Проверить сортировку стран и геозон в админке
         * Сделайте сценарии, которые проверяют сортировку стран и геозон (штатов) в учебном приложении litecart.
         * 1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
         * а) проверить, что страны расположены в алфавитном порядке
         * б) для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и там проверить, что зоны расположены в алфавитном порядке
         * 
         * 2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
         * зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке*/

        //1
        [Test]
        public void CanCountriesSort()
        {
            app.AdminLoginPanel("admin", "admin");
            app.CheckCountriesSort();

        }
        //2
        [Test]
        public void CanGeoZoneSort()
        {
            app.AdminLoginPanel("admin", "admin");
            app.CheckGeoZoneSort();
        }
    }
}
