using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.data
{
    public class ProductsData
    {
        public string Name { get; internal set; }
        public string Code { get; internal set; }
        public string Keywords { get; internal set; }
        public string ShortDescription { get; internal set; }
        public string Description { get; internal set; }
        public string HeadTitle { get; internal set; }
        public string MetaDescription { get; internal set; }
        public string Quantity { get; internal set; }
        public string ImagePath { get; internal set; }
        public string DateFrom { get; internal set; }
        public string DateTo { get; internal set; }
        public string PurchasePrice { get; internal set; }




        public ProductsData(string name, string path)
        {
            Name = name;
            ImagePath = GetImagePath(path);
            Code = GetCodeProduct();
            Quantity = GetQuantity();
            string tm = GetRandomDate();
            DateFrom = tm.Split(':')[0];
            DateTo = tm.Split(':')[1];
            Keywords = "Key1 Key2 Key3";
            ShortDescription = "Short description about product";
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            HeadTitle = "Head title";
            MetaDescription = "Meta description";
            PurchasePrice = GetRandomPurchasePrice();
        }
        private string GetCodeProduct()
        {
            return new Random().Next(1000, 9999).ToString();
        }

        private string GetQuantity()
        {
            return Convert.ToString(new Random().Next(1, 200));
        }

        private string GetRandomDate()
        {
            string dtFrom = DateTime.Now.ToString("yyyy-MM-dd");
            string dtTo = DateTime.Now.AddMonths(+new Random().Next(1, 7)).ToString("yyyy-MM-dd");
            return $"{dtFrom}:{dtTo}";
        }

        private string GetRandomPurchasePrice()
        {
            return Convert.ToString(new Random().Next(1, 500));
        }

        private string GetImagePath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}
