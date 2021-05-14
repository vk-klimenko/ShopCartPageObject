using NUnit.Framework;
using ShopCartPageObject.data;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class RegistrationCustomerTests:TestBase
    {
        /*
         * Задание 11. Сделайте сценарий регистрации пользователя
         * Сделайте сценарий для регистрации нового пользователя в учебном приложении litecart (не в админке, а в клиентской части магазина).
         * Сценарий должен состоять из следующих частей:
         * 1) регистрация новой учётной записи с достаточно уникальным адресом электронной почты 
         * (чтобы не конфликтовало с ранее созданными пользователями, в том числе при предыдущих запусках того же самого сценария),
         * 2) выход (logout), потому что после успешной регистрации автоматически происходит вход,
         * 3) повторный вход в только что созданную учётную запись,
         * 4) и ещё раз выход.
         */

        [Test]
        public void CanRegistration()
        {
            CustomersData customer = new CustomersData();
            app.RegisterNewCustomer(customer);
        }
    }
}
