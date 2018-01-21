using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new ProductManager(new Factory3());
            manager.GetAll();
            Console.ReadLine();
        }
    }

    #region Logging

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log with Log4NetLogger");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log with NLogger");
        }
    }

    #endregion

    #region Caching

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with RedisCache");
        }
    }

    #endregion

    public abstract class CrossCuttingConcernsFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory1
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory1
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory3 : CrossCuttingConcernsFactory1
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory1 _crossCuttingConcernsFactory1;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory1 crossCuttingConcernsFactory1)
        {
            _crossCuttingConcernsFactory1 = crossCuttingConcernsFactory1;
            _logging = _crossCuttingConcernsFactory1.CreateLogger();
            _caching = _crossCuttingConcernsFactory1.CreateCaching();
        }

        public void GetAll()
        {
            Console.WriteLine("Products listed");
            _caching.Cache("Cache My Data");
            _logging.Log("Log My Message");
        }
    }
}