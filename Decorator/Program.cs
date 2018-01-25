using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "Opel", Model = "Astra", HirePrice = 3000 };
            var specialOffer = new SpecialOffer(personalCar);
            Console.WriteLine("personalCar offer : {0}", personalCar.HirePrice);
            specialOffer.DiscountPercentage = 15;
            Console.WriteLine("Special offer : {0}", specialOffer.HirePrice);
            Console.ReadLine();
        }
    }

    public abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    public class PersonalCar : CarBase
    {
        public override decimal HirePrice { get; set; }

        public override string Make { get; set; }

        public override string Model { get; set; }
    }

    public class CommercialCar : CarBase
    {
        public override decimal HirePrice { get; set; }

        public override string Make { get; set; }

        public override string Model { get; set; }
    }

    public abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carbase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carbase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {

        private readonly CarBase _carbase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carbase = carBase;
        }

        public int DiscountPercentage { get; set; }

        public override decimal HirePrice
        {
            get { return _carbase.HirePrice - _carbase.HirePrice * DiscountPercentage / 100; }
            set { }
        }

        public override string Make { get; set; }

        public override string Model { get; set; }
    }
}
