using System;

namespace Facede
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();


            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Caching!");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("UserCheck!");
        }
    }

    internal interface IAuthorize
    {
        public void CheckUser();
    }


    class Validater : IValidate
    {
        public void Validation()
        {
            Console.WriteLine("Validate!");
        }
    }

    internal interface IValidate
    {
        public void Validation();
    }

    class CustomerManager
    {

        CrossCuttingConcernFacede _facede;

        public CustomerManager()
        {
            _facede = new CrossCuttingConcernFacede();
        }


        public void Save()
        {
            _facede.Caching.Cache();
            _facede.Logging.Log();
            _facede.Authorize.CheckUser();
            _facede.Validate.Validation();
            Console.WriteLine("Saved!");
        }

    }

    class CrossCuttingConcernFacede
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;


        public CrossCuttingConcernFacede()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validater();
        }
    }
}
