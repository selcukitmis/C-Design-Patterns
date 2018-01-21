using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetViewModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.Name);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.ReadLine();
        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    public abstract class ProductBuilder
    {
        public abstract void GetProduct();
        public abstract void ApplyDiscount();

        public abstract ProductViewModel GetViewModel();
    }

    public class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override void GetProduct()
        {
          

            model.Id = 1;
            model.Name = "Çay";
            model.CategoryName = "İçecek";
            model.UnitPrice = 20;
        }

        public override ProductViewModel GetViewModel()
        {
            return model;
        }
    }

    public class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override void GetProduct()
        {
            model.Id = 1;
            model.Name = "Çay";
            model.CategoryName = "İçecek";
            model.UnitPrice = 20;
        }

        public override ProductViewModel GetViewModel()
        {
            return model;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder builder)
        {
            builder.GetProduct();
            builder.ApplyDiscount();
        }
    }

}
