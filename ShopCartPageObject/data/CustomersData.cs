using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.data
{
    public class CustomersData
    {
        private Random rnd = new Random();
        public string Address { get; internal set; }
        public string City { get; internal set; }
        public string Country { get; internal set; }
        public string Zone { get; internal set; }
        public string Email { get; internal set; }
        public string Firstname { get; internal set; }
        public string Lastname { get; internal set; }
        public string Password { get; internal set; }
        public string Phone { get; internal set; }
        public string Postcode { get; internal set; }


        public CustomersData()
        {
            this.Address = "17 North Street";
            this.City = "Manchester";
            this.Country = "US";
            this.Zone = "NH";
            this.Email = GetRandomEmail();
            this.Firstname = "Adam";
            this.Lastname = "Sandler";
            this.Password = "Qwerty";
            this.Phone = GetPhoneNumFormat();
            this.Postcode = GetCodeNumber();
        }

        
        /// <summary>
        /// Генератор рандомной эл. почты
        /// </summary>
        /// <returns>Email</returns>
        private string GetRandomEmail()
        {
            var str = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                str.Append((char)rnd.Next('a', 'z'));
            }
            string email = str.ToString();
            return $"{email}{rnd.Next(1, 100)}@gmail.com";
        }

        /// <summary>
        /// Генератор телефонного номера
        /// </summary>
        /// <returns>Номер в формате "+1 (###) (####)-(##)-(##)"</returns>
        private string GetPhoneNumFormat()
        {
            return $"+1 {rnd.Next(100, 999)} {rnd.Next(1000, 9999)} {rnd.Next(10, 99)} {rnd.Next(10, 99)}";
        }

        /// <summary>
        /// Генератор индекса страны
        /// </summary>
        /// <returns>Пятизначный индекс</returns>
        private string GetCodeNumber()
        {
            string code = String.Empty;

            for (int i = 0; i < 5; i++)
            {
                code += rnd.Next(1, 9);
            }
            return code;
        }
    }
}
