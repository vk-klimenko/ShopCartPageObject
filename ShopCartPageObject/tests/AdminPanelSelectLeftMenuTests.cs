using NUnit.Framework;
namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class AdminPanelMenuTests:TestBase
    {
        /*
         * Задание 7. Сделайте сценарий, проходящий по всем разделам админки
         * Сделайте сценарий, который выполняет следующие действия в учебном приложении litecart.
         * 1) входит в панель администратора http://localhost/litecart/admin
         * 2) прокликивает последовательно все пункты меню слева, включая вложенные пункты
         * 3) для каждой страницы проверяет наличие заголовка (то есть элемента с тегом h1)
         */
        [Test]
        public void CanSelectLeftMenu()
        {
            app.AdminLoginPanel("admin", "admin");
            app.SelectLeftMenu();
        }
    }
}
