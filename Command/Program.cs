using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new StockManager();
            var buyStock = new BuyStock(manager);
            var sellStock = new SellStock(manager);

            var controller = new StockController();
            controller.TakeOrder(buyStock);
            controller.TakeOrder(sellStock);
            controller.TakeOrder(buyStock);

            controller.PlaceOrders();

            Console.ReadLine();

        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            _quantity++;
            Console.WriteLine("Stock : {0}, {1} bought!", _name, _quantity);
        }

        public void Sell()
        {
            _quantity--;
            Console.WriteLine("Stock : {0}, {1} sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        StockManager _manager;

        public BuyStock(StockManager manager)
        {
            _manager = manager;
        }

        public void Execute()
        {
            _manager.Buy();
        }
    }

    class SellStock : IOrder
    {
        StockManager _manager;

        public SellStock(StockManager manager)
        {
            _manager = manager;
        }
        public void Execute()
        {
            _manager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }

}
