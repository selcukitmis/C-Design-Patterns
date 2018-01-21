using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee selcuk = new Employee { Name = "Selçuk" };
            Employee erman = new Employee { Name = "Erman" };
            Employee faruk = new Employee { Name = "Faruk" };
            Employee mahmut = new Employee { Name = "Mahmut" };
            selcuk.AddSubordinate(erman);
            erman.AddSubordinate(faruk);
            faruk.AddSubordinate(mahmut);

            var contractor1 = new Contractor { Name = "Uğur Yorulmaz"};
            var contractor2 = new Contractor { Name = "Murat Yavuzkaplan" };
            mahmut.AddSubordinate(contractor1);
            mahmut.AddSubordinate(contractor2);
            Console.WriteLine("manager " + selcuk.Name);
            foreach (Employee submanager in selcuk)
            {
                Console.WriteLine("  submanager " + submanager.Name);

                foreach (Employee worker1 in submanager)
                {
                    Console.WriteLine("    worker1 " + worker1.Name);
                    foreach (Employee worker2 in worker1)
                    {
                        Console.WriteLine("      worker2 " + worker2.Name);

                        foreach (Contractor contractor in worker2)
                        {
                            Console.WriteLine("        contractor " + contractor.Name);
                        }

                    }
                }
            }

            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    public class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var item in _subordinates)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
