using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer { Id = 1, City = "İstanbul", Name = "Selçuk", Surname = "İTMİŞ" };

            var customer2 = (Customer)customer1.Clone();
            customer2.Name = "Mahmut";

            Console.WriteLine(customer1.Name);
            Console.WriteLine(customer2.Name);
            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
