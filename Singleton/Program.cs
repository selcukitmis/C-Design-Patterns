using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            // multi thread kullanımında aynı anda istek gelirse işlemi lock ediyoruz. Bir sonraki istek lock ın tamamlanmasını bekliyor ve sonra çalışıyor.
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
                return _customerManager;
            }
        }

        public void Save()
        {
            Console.Write("Saved");
        }
    }
}