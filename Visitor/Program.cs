using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager { Name = "Selçuk", Salary = 1000 };
            var manager2 = new Manager { Name = "Aslı", Salary = 2000 };
            var worker = new Worker { Name = "Erman", Salary = 800 };
            var worker2 = new Worker { Name = "Faruk", Salary = 700 };

            manager.SubOrdinates.Add(manager2);
            manager2.SubOrdinates.Add(worker);
            manager2.SubOrdinates.Add(worker2);

            var structure = new OrganizationalStructure(manager);

            var payrollVisitor = new PayrollVisitor();
            var payrise = new Payrise();

            //structure.Accept(payrollVisitor);
            structure.Accept(payrise);
            Console.Read();

        }
    }

    class OrganizationalStructure
    {
        public EmployeeBase Employee;

        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {

        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            SubOrdinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> SubOrdinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in SubOrdinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }



    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {


        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid for worker {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid for manager {1}", manager.Name, manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to for worker {1}", worker.Name, worker.Salary * (decimal) 1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to for manager {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}
