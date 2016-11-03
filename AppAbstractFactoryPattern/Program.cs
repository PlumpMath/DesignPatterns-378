using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbstractFactoryPattern
{
    class AbstractFactoryPttrn
    {
        string str = "classs";
        interface INormal 
        {
            string DisplayBase();

        }
        interface IAboveNormal
        {
            string DisplayAboveNormal();
        }

        class clsWagnor : INormal 
        {

            public string DisplayBase()
            {
                return "WagonR";
            }
        }
        class clsSwift : IAboveNormal
        {

            public string DisplayAboveNormal()
            {
                return "Swift";
            }
        }
        class clsAudiA7 : INormal
        {

            public string DisplayBase()
            {
                return "Audi A7";
            }
        }
        class clsAudiQ4: IAboveNormal
        {

            public string DisplayAboveNormal()
            {
                return "Audi Q4";
            }
        }

        interface ICar
        {
            INormal getNormal();
            IAboveNormal getAboveNormal();
        }

        class clsMaruti : ICar
        {

            public INormal getNormal()
            {
                return new clsWagnor();
            }

            public IAboveNormal getAboveNormal()
            {
                return new clsSwift();
            }
        }
        class clsAudi :ICar
        {

            public INormal getNormal()
            {
                return new clsAudiA7();
            }

            public IAboveNormal getAboveNormal()
            {
                return new clsAudiQ4();
            }
        }

        class clsDecider
        {
            public string GetCarDetails(int iCarType)
            {
                ICar  ObjClient = null;
                switch (iCarType)
                {
                    case 1:
                        ObjClient = new clsMaruti();
                        break;
                    case 2:
                        ObjClient = new clsAudi();
                        break;
                    default:
                        ObjClient = new clsMaruti();
                        break;
                }

                string sOutput = "Normal Car is: " + ObjClient.getNormal().DisplayBase() + ", Above Normal car is: " + ObjClient.getAboveNormal().DisplayAboveNormal();
                return sOutput;
            }
        }

        static void Main(string[] args)
        {
            clsDecider objDecider = new clsDecider();
            string result = objDecider.GetCarDetails(1);
            Console.WriteLine(result);
            Console.WriteLine();

            result = objDecider.GetCarDetails(2);
            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
