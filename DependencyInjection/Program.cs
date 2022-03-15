using Ninject;
using System;

namespace DependencyInjection
{
    //SOLID
    //D=>Dependecy Inversion
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();


            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();


            Console.ReadLine();
        }
    }

    //IoC container'ları bir kutuya benzetebiliriz.
    //Bu kutu içerisinde Dependency'leri set ederiz.
    //Arka tarafta FactoryMethod ve Factory Design Patternlerini kullanan bir yağıya sahiptir.


    interface IProductDal
    {
        void Save();
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved to EF!");
        }
    }

    class DBProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved to DB!");
        }
    }

    class ProductManager
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {

            _productDal.Save();
        }
    }
}
