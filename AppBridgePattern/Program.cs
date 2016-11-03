using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBridgePattern
{
     // Bridge patterns allows the abstraction and the implementation to be developed independently and client code can access only the 
    //  abstraction part without beign cocerned about the implmentation 

     //In bridge pattern there are two parts, 
    // A) Abstraction Layer
    // B) Implementation  Layer
    class Program
    {
        // This bridge interface between the abstraction and the implementation
        interface ColorImplementator
        {
             void fillColor();
        }

        // Abstraction Layer
        abstract class Shape 
        {
            protected ColorImplementator color;

            public ColorImplementator getColor()
            {
                return color; 
            }
            public void setColor(ColorImplementator colorVal)
            {
                color = colorVal;
            }
            
            abstract public void Draw();
            abstract public void ColorIt();
        }

        // Concerte class for the abstraction
        class Circle : Shape 
        {

            public override void Draw()
            {
                Console.WriteLine("Circle Drawed at the given location \n");
            }

            public override void ColorIt()
            {
                Console.WriteLine("Colored the circle with specified color \n");
                color.fillColor();
                
            }
        }
        // Concerte class for the abstraction
        class Rectangle : Shape
        {

            public override void Draw()
            {
               Console.WriteLine("Rectangle Drawed at the given location \n");
            }

            public override void ColorIt()
            {
                Console.WriteLine("Colored the rectangle with specified color \n");
                color.fillColor();
            }
        }


        //Implementation  Layer
        class BlueColorImplementator : ColorImplementator 
        {

            public void fillColor()
            {
                Console.WriteLine("Blue color implementor is used to color the object");
            }
        }
        //Implementation  Layer
        class GreenColorImplementator : ColorImplementator
        {

            public void fillColor()
            {
                Console.WriteLine("Green color implementor is used to color the object");
            }
        }


        // Client Code
        // Client can access the abstraction layer 
        static void Main(string[] args)
        {
            Shape rectangleShape = new Rectangle();
            rectangleShape.Draw();
            
            Shape CircleShape = new Circle();
            CircleShape.Draw();

            rectangleShape.setColor(new GreenColorImplementator());
            rectangleShape.ColorIt();


            CircleShape.setColor(new BlueColorImplementator());
            CircleShape.ColorIt();



        }
    }
}
