using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new CreditManagerProxy();
            var r1 = manager.Calculate();
            Console.WriteLine("R1: " + r1);
            var r2 = manager.Calculate();
            Console.WriteLine("R2: " + r2);
            Console.ReadLine();
        }
    }

    public abstract class CreditBase
    {
        public abstract int Calculate();
    }

    public class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 2;
            for (int i =1; i < 4; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    public class CreditManagerProxy : CreditBase
    {
        private CreditManager _manager;
        private int _cachedValue;
        
        public override int Calculate()
        {
            if (_manager == null)
            {
                _manager = new CreditManager();
                _cachedValue = _manager.Calculate();
            }

            return _cachedValue;
        }
    }
}
