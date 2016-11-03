using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChainOfResponsibiltyPattern
{
    class Purchase
    {
        public Purchase(int number, double amount, string purpose)
        {
            _number = number;
            _amount = amount;
            _purpose = purpose;
        }
        int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        string _purpose;

        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        
    }

    abstract class Aprrover
    {
        public Aprrover _sucessor;
        public void SetSuccessor(Aprrover successor)
        {
            _sucessor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }

    class Director : Aprrover 
    {

        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 500)
            {
                Console.WriteLine("{0} approved request# {1} \n",this.GetType().Name, purchase.Number);
            }
            else if (_sucessor != null)
            {
                _sucessor.ProcessRequest(purchase);
            }
        }
    }
    class VicePresident : Aprrover 
    {

        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 5000)
            {
                Console.WriteLine("{0} approved request# {1} \n", this.GetType().Name, purchase.Number);
            }
            else if (_sucessor != null)
            {
                _sucessor.ProcessRequest(purchase);
            }
        }
    }
    class President : Aprrover 
    {

        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 50000)
            {
                Console.WriteLine("{0} approved request# {1} \n", this.GetType().Name, purchase.Number);
            }
            else if (_sucessor != null)
            {
                _sucessor.ProcessRequest(purchase);
            }
            else
            {
                Console.WriteLine("Request# {0} requires an executive meeting! \n", purchase.Number);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Aprrover ram = new Director();
            Aprrover meg = new VicePresident ();
            Aprrover nav = new President();
            ram.SetSuccessor(meg);
            meg.SetSuccessor(nav);

            Purchase p = new Purchase(2077, 340.98, "Project X");
            ram.ProcessRequest(p);

            p = new Purchase(2078, 4340.98, "Project Y");
            ram.ProcessRequest(p);


            p = new Purchase(2079, 45340.98, "Project Z");
            ram.ProcessRequest(p);

            p = new Purchase(2080, 155340.98, "Project ZA");
            ram.ProcessRequest(p);


        }
    }
}
