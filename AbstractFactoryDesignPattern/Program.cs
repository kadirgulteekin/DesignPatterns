using System;

namespace AbstractFactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net!");
        }
    }


    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger!");
        }
    }

    public abstract class Cashing
    {
        public abstract void Cache(string data);
        
    }

    public class MemCache : Cashing
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    public class RedisCache : Cashing
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    public abstract class CrossCuttingConcerncsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Cashing CreateCaching();
    }

    public class Factory1 : CrossCuttingConcerncsFactory
    {
        public override Cashing CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossCuttingConcerncsFactory
    {
        public override Cashing CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }


    public class ProductManager
    {

        //Dependecy Injection
        CrossCuttingConcerncsFactory _crossCuttingConcerncsFactory;

        Logging _logging;
        Cashing _cashing;
        public ProductManager(CrossCuttingConcerncsFactory crossCuttingConcerncsFactory)
        {
            _crossCuttingConcerncsFactory = crossCuttingConcerncsFactory;
            _logging = crossCuttingConcerncsFactory.CreateLogger();
            _cashing = crossCuttingConcerncsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _cashing.Cache("Data");
            Console.WriteLine("Products Listed!");
        }
    }
}
