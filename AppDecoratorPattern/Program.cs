using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDecoratorPattern
{
    public abstract class BakeryComponent 
    {
        public abstract string GetName();
        public abstract double GetPrice();
    }

    class CakeBase : BakeryComponent 
    {
        private string m_Name = "Cake Base";
        private double m_Price = 200.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }
    class PastryBase : BakeryComponent
    {
        private string m_Name = "Pastry Base";
        private double m_Price = 300.0;
        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }

    class Decorator : BakeryComponent
    {
        BakeryComponent m_BaseComponent = null;
        protected string m_Name = "Undefined Decorator";
        protected double m_Price = 0.0;

        public override string GetName()
        {
            return string.Format("{0} + {1} ", m_BaseComponent.GetName(), m_Name);
        }

        public override double GetPrice()
        {
            return m_Price + m_BaseComponent.GetPrice();
        }
        protected Decorator(BakeryComponent bakeryComponent)
        {
            m_BaseComponent = bakeryComponent;
        }
    }

    class ArtificalScentDecorator : Decorator
    {
        public ArtificalScentDecorator(BakeryComponent baseComponent) : base(baseComponent)
        {
            this.m_Name = "Aritifical Scent";
            this.m_Price = 3.0;
        }
    }
    class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent baseComponent) : base(baseComponent)
        {
            this.m_Name = "Cherry ";
            this.m_Price = 2.0;
        }
    }

    class CreamDecorator : Decorator
    {
        public CreamDecorator(BakeryComponent baseComponent): base(baseComponent)
        {
            this.m_Name = "Cream";
            this.m_Price = 4.0;
        }
    }

    class NameCardDecorator : Decorator
    {
        int m_DiscountRate = 5;
        public NameCardDecorator(BakeryComponent baseComponent) :base(baseComponent)
        {
            this.m_Name = "Name Card";
            this.m_Price = 5.0;
        }
        public override string GetName()
        {
            return base.GetName() + string.Format("\n(Please Collect your discount card for {0}%)", m_DiscountRate);
    }    
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Let us create a Simple Cake Base first
            CakeBase cBase = new CakeBase();
            PrintProductDetails(cBase);


            // Lets add cream to the cake
            CreamDecorator creamCake = new CreamDecorator(cBase);
            PrintProductDetails(creamCake);

            // Let now add a Cherry on it
            CherryDecorator cherryCake = new CherryDecorator(creamCake);
            PrintProductDetails(cherryCake);

            // Lets now add Scent to it
            ArtificalScentDecorator scentedCake = new ArtificalScentDecorator(cherryCake);
            PrintProductDetails(scentedCake);

            // Finally add a Name card on the cake
            NameCardDecorator nameCardOnCake = new NameCardDecorator(scentedCake);
            PrintProductDetails(nameCardOnCake);

            // Lets now create a simple Pastry
            PastryBase pastry = new PastryBase();
            PrintProductDetails(pastry);

            // Lets just add cream and cherry only on the pastry 
            CreamDecorator creamPastry = new CreamDecorator(pastry);
            CherryDecorator cherryPastry = new CherryDecorator(creamPastry);
            PrintProductDetails(cherryPastry);
        }
        private static void PrintProductDetails(BakeryComponent product)
        {
            Console.WriteLine(); // some whitespace for readability
            Console.WriteLine("Item: {0}, Price: {1}", product.GetName(), product.GetPrice());
        }
        
    }
}
