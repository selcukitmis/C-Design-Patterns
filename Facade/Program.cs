using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new CustomerManager();
            manager.Save();
            Console.ReadLine();
        }
    }

    public class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    public interface ILogging
    {
        void Log();
    }

    public class Caching : ICache 
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    public interface ICache
    {
        void Cache();
    }

    public class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    public interface IAuthorize
    {
        void CheckUser();
    }

    public class CustomerManager
    {

        CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.caching.Cache();
            _concerns.authorize.CheckUser();
            _concerns.logging.Log();
            Console.WriteLine("Saved");
        }
    }

    public class CrossCuttingConcernsFacade
    {
        public ILogging logging;
        public ICache caching;
        public IAuthorize authorize;

        public CrossCuttingConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
        }
    }

}