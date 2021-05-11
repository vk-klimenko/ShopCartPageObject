using NUnit.Framework;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class AdminLoginTests : TestBase
    {
        /*
         * Задание 3. Сделайте сценарий логина
         * Сделайте сценарий логина
         * Сделайте сценарий для логина в панель администрирования
         * учебного приложения http://localhost/litecart/admin/.
         */
        [Test]
        public void CanLogin()
        {
            app.AdminLoginPanel("admin", "admin");
            
        }
    }
}
