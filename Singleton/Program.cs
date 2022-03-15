using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager= CustomerManager.CreateAsSingleton();
            customerManager.Save();
            
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager; //instance

        static object _lockObject = new object();
        private CustomerManager() //Dış erişime kapalı bir nesne
        {

        }
        public static CustomerManager CreateAsSingleton()
        {

            lock (_lockObject) //Singleton işlemini Sadetly hale getiriyor bir nesnenin aynı anda iki kez new'lenmesini engelliyor.
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }


            return _customerManager;
        }

        public  void Save()
        {
            Console.WriteLine("Saved");
        }

    }
}
