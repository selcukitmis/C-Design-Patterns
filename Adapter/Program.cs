using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager(new Log4NetAdapter());
            manager.Save();
            Console.ReadLine();
        }
    }

    public class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message + " logged!");
        }
    }


    public class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message + " logged with log4net!");
        }
    }

    public class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4net = new Log4Net();
            log4net.LogMessage("my log message");
        }
    }
}