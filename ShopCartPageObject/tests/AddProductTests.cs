using NUnit.Framework;
using ShopCartPageObject.data;

namespace ShopCartPageObject.tests
{
    [TestFixture]
    public class AddProductTests:TestBase
    {
        /*
         * Задание 12. Сделайте сценарий добавления товара
         * Сделайте сценарий для добавления нового товара (продукта) в учебном приложении litecart (в админке).
         * Для добавления товара нужно открыть меню Catalog, в правом верхнем углу нажать кнопку "Add New Product", заполнить поля с информацией о товаре и сохранить.
         * Достаточно заполнить только информацию на вкладках General, Information и Prices. Скидки (Campains) на вкладке Prices можно не добавлять.
         * Переключение между вкладками происходит не мгновенно, поэтому после переключения можно сделать небольшую паузу 
         * (о том, как делать более правильные ожидания, будет рассказано в следующих занятиях).
         * Картинку с изображением товара нужно уложить в репозиторий вместе с кодом. При этом указывать в коде полный абсолютный путь к файлу плохо, 
         * на другой машине работать не будет. Надо средствами языка программирования преобразовать относительный путь в абсолютный.
         * После сохранения товара нужно убедиться, что он появился в каталоге (в админке). Клиентскую часть магазина можно не проверять.
         */
        [Test]
        public void CanAddProduct()
        {
            ProductsData product = new ProductsData("Book", @"\image.png");
            app.AddNewProduct(product);
        }
    }
}
