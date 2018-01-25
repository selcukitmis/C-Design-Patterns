using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new CustomerManagerTests();
            
            manager.SaveTest();

            var manager2 = new CustomerManager(StubLogger.GetLogger());
            manager2.Save();

            var manager3 = new CustomerManager(new NLogger());
            manager3.Save();

            Console.Read();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {

        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    class NLogger : ILogger
    {

        public void Log()
        {
            Console.WriteLine("Logged with NLogger");
        }
    }


    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        private StubLogger()
        {
            
        }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }

        public void Log()
        {
            
        }
    }

    class CustomerManager
    {
        private ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager manager = new CustomerManager(StubLogger.GetLogger());
            manager.Save();
        }
    }

}
