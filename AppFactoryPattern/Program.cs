using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFactoryPattern
{

    class FactoryPattern
    {
        // 1. Create the interface which have the common method
        interface ILogger 
        {
            int log(string strMessage);
        }
        //2. Create some concerte classes which can implement the Interface
        class DatabaseLogger : ILogger
        {

            public int log(string strMessage)
            {
                //a.  open the DB connection 
                // b. Update the log in the corresponding table 
                Console.WriteLine("\nopen the DB connection \nUpdate the log in the corresponding table ");
                Console.WriteLine(strMessage);
                return 1;
                //throw new NotImplementedException();
            }
        }
        class FileLogger : ILogger
        {

            public int log(string strMessage)
            {
                //a.  open the File pointer 
                // b. Update the log in the corresponding file
                Console.WriteLine("\nopen the File pointer \nUpdate the log in the corresponding file ");
                Console.WriteLine(strMessage);
                return 1;
                //throw new NotImplementedException();
            }
        }

        class ConsoleLogger : ILogger
        {

            public int log(string strMessage)
            {
                Console.WriteLine();
                Console.WriteLine(strMessage);
                return 1;
            }
        }

        class AppLoggerFactory
        {
            public ILogger CreateLogger(int iType) 
            {
                if (iType == 1)
                {
                    return new DatabaseLogger();
                }
                else if (iType == 2)
                {
                    return new FileLogger();
                }
                else if (iType == 3)
                {
                    return new ConsoleLogger();
                }
                else
                {
                    return null;
                }
            }
        }
        static void Main(string[] args)
        {
            AppLoggerFactory applog = new AppLoggerFactory();
            ILogger log;

            for (int i = 1; i < 4; i++)
			{
                log = applog.CreateLogger(i);
                log.log("Updated the data in "+ i+ " logger");
			}
            
        }
    }
}
