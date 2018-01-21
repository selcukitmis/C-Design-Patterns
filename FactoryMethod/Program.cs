using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // en sık kullanılanlardan biridir. Amaç yazılımda değişimi kontrol altında tutmaktır.
            CustomerManager manager = new CustomerManager(new FirebaseLoggerFactory());
            manager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // burada istediğimiz loglama türünü dönebiliriz. 
            // yarın logger türü değişirse tek yerden değişim yaparız. 
            // ya da logu db ye mi firebase mi txt ye mi nereye kaydetmek istersek kaydedebiliriz.
            return new SelcukLogger();
        }
    }

    public class FirebaseLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // burada istediğimiz loglama türünü dönebiliriz. 
            // yarın logger türü değişirse tek yerden değişim yaparız. 
            // ya da logu db ye mi firebase mi txt ye mi nereye kaydetmek istersek kaydedebiliriz.
            return new FirebaseLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class SelcukLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with SelcukLogger");
        }
    }

    public class FirebaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with FirebaseLogger");
        }
    }


    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
