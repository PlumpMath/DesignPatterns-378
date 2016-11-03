using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSingletonPattern
{
   
        class SingleTon
        {
            private volatile static SingleTon singleTonObject;
            private SingleTon()
            {
            }

            public static SingleTon CreateInstance()
            {
                object lockingObject = new object();
                if (singleTonObject == null)
                {
                    lock (lockingObject)
                    {
                        if (singleTonObject == null)
                        {
                            singleTonObject = new SingleTon();
                        }
                    }
                }
                return singleTonObject;
            }
            public void Display()
            {
                Console.WriteLine("My SingleTon Class");
            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                SingleTon objsing = SingleTon.CreateInstance();
                objsing.Display();
            }
        }
}
