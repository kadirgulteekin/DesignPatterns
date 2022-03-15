using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);

            Console.ReadLine();
        }

        
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

     abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();

        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice*(decimal)0.90;
            productViewModel.DiscountApplied = true;

        }

        public override ProductViewModel GetModel()
        {
            return productViewModel;
        }

        public override void GetProductData()
        {
            productViewModel.Id = 1;
            productViewModel.CategoryName = "Beverage";
            productViewModel.ProductName = "Chai";
            productViewModel.UnitPrice = 500;
        }

    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice;
            productViewModel.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return productViewModel;
        }

        public override void GetProductData()
        {
            productViewModel.Id = 2;
            productViewModel.CategoryName = "Simit";
            productViewModel.ProductName = "Kahvaltılık";
            productViewModel.UnitPrice = 3;
        }

    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();

        }
    }



}
