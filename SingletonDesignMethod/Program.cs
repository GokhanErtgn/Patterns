using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            DbHelper helper1 = DbHelper.CreateDbHelper("test connection");
            helper1.StateMessage = "Example Message";

            DbHelper helper2 = DbHelper.CreateDbHelper("another test");
            Console.WriteLine(helper2.StateMessage);
            Console.ReadLine();
        }
    }
    public class DbHelper
    {
        private DbHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private static DbHelper _helper;

        public static DbHelper CreateDbHelper(string connectionString)
        {
            if (_helper==null)
            {
                _helper = new DbHelper(connectionString);
            }
            return _helper;
        }

        public string ConnectionString { get; set; }
        public string  StateMessage { get; set; }
    }
}
