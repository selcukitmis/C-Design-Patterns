using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            var vicePresident = new VicePresident();
            var president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            var expense = new Expense { Detail = "Training", Amount = 1000 };
            manager.HandleExpense(expense);
            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;

        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager Handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
            else
            {
                Console.WriteLine("Expense can not to Handle from Manager");
            }
        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("VicePresident Handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
            else
            {
                Console.WriteLine("Expense can not to Handle from vice president");
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            Console.WriteLine("President Handled the expense!");
        }
    }
}
