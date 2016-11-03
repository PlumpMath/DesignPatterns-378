using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCompositePattern
{
    public interface IEmployee 
    {
        void showHappiness();
    }
    class Worker : IEmployee
    {
        private int happiness;
        private string name;
        public Worker(string name, int happiness)
        {
            this.name = name;
            this.happiness = happiness;
        }
        public void showHappiness()
        {
           Console.WriteLine("\t " + name + " showed happiness level of " + happiness);
        }
    }

    class Supervisor : IEmployee
    {
        private List<IEmployee> subordinate = new List<IEmployee>();
        private int happiness;
        private string name;
        public Supervisor(string name, int happiness)
        {
            this.name = name;
            this.happiness = happiness;
        }
        public void showHappiness()
        {
            Console.WriteLine();
            Console.WriteLine(name + " showed happiness level of " + happiness);
            //show all the subordinate's happiness level
            foreach (IEmployee i in subordinate)
                i.showHappiness();
        }

        public void AddSubordinate(IEmployee employee)
        {
            subordinate.Add(employee);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker("Tom", 5);
            Worker worker2 = new Worker("Sam", 6);
            Worker worker3 = new Worker("Joe", 7);
            Worker worker4 = new Worker("Alain", 8);

            Supervisor b = new Supervisor("Supervisor Mary", 6);
            Supervisor c = new Supervisor("Supervisor Jerry", 7);
            Supervisor d = new Supervisor("Supervisor Bob", 9);
            Worker e = new Worker("Worker Jimmy", 8);

            b.AddSubordinate(worker1);
            b.AddSubordinate(worker2);
            c.AddSubordinate(worker3);
            c.AddSubordinate(worker4);

            d.AddSubordinate(e);

            if (c is IEmployee )
            {
                c.showHappiness();
            }

            if (b is IEmployee)
            {
                b.showHappiness();
            }

            if (d is IEmployee)
            {
                d.showHappiness();
            }

        }
    }
}
