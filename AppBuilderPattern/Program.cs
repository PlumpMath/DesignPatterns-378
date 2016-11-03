using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBuilderPattern
{
    public enum ScreenType 
    {
        ScreenType_TOUCH_CAPACITIVE,
        ScreenType_TOUCH_RESISTIVE,
        ScreenType_NON_TOUCH
    };

    public enum BatteryType
    {
        MAH_1000,
        MAH_2000,
        MAH_3000
    };
    public enum OperatingSystem
    {
        ANDRIOD,
        WINDOWS,
        SYMBIAN,
        BLACKBERY_OS
    };
    public enum Stylus
    {
        YES,
        NO
    };
    
    //Now let us look the the Product class. 
    //We need to have a Product that can be created by assembling there parts
    //so lets have a class called MobilePhone which will be the Product class for us.

    class MobilePhone 
    {
        string phoneName;
        ScreenType phoneScreenType;
        BatteryType phoneBatteryType;
        OperatingSystem phoneOS;
        Stylus phoneStylus;

        public MobilePhone(string name)
        {
            phoneName = name;
        }
        public ScreenType PhoneScreenType
        {
            get
            {
                return phoneScreenType;
            }
            set
            {
                phoneScreenType = value;
            }
        }
        public BatteryType PhoneBatteryType
        {
            get
            {
                return phoneBatteryType;
            }
            set
            {
                phoneBatteryType = value;
            }
        }
        public OperatingSystem PhoneOS
        {
            get
            {
                return phoneOS;
            }
            set
            {
                phoneOS = value;
            }
        }
        public Stylus PhoneStylus
        {
            get
            {
                return phoneStylus;
            }
            set
            {
                phoneStylus = value;
            }
        }
      
        // Methiod to display phone details in our own representation
        public override string ToString()
        {
            return string.Format("Name: {0}\nScreen: {1}\nBattery {2}\nOS: {3}\nStylus: {4}",
                phoneName, PhoneScreenType, PhoneBatteryType, PhoneOS, PhoneStylus);
        }
    };

    //Now since we have the Product class ready with us lets work on creating the Builder.
    //The Builder should provide the functions for creating each of the parts for any phone.
    //So let us create an interface for Builder as IPhoneBuilder and look at it.

    interface IPhoneBuilder
    {
        void BuildScreen();
        void BuildBattery();
        void BuildOS();
        void BuildStylus();
        MobilePhone Phone { get; }
        
    }

    //Now we have the Builder interface ready, the next thing would be to have the ConcreteBuilder objects in place.
    //Let us assume that the manufacturer is planning for an Android phone and one Windows Phone 
    //so we will be needing two ConcreteBuilder for these phones i.e. AndroidPhoneBuilder and WindowsPhoneBuilder.
    //Inside these builders we can specify the type of parts we want to use for each phone.

    class AndroidPhoneBuilder : IPhoneBuilder
    {
        MobilePhone phone;
        public AndroidPhoneBuilder()
        {
            phone = new MobilePhone("Android Phone");
        }
  
        public void BuildScreen()
        {
            phone.PhoneScreenType = ScreenType.ScreenType_TOUCH_RESISTIVE;
        }

        public void BuildBattery()
        {
            phone.PhoneBatteryType = BatteryType.MAH_2000;
        }

        public void BuildOS()
        {
            phone.PhoneOS = OperatingSystem.ANDRIOD;
        }

        public void BuildStylus()
        {
            phone.PhoneStylus = Stylus.YES;
        }

        public MobilePhone Phone
        {
            get { return phone; }
        }
    }
    class WindowsPhoneBuilder :IPhoneBuilder
    {
        MobilePhone phone;
        public WindowsPhoneBuilder()
        {

            phone = new MobilePhone("Window Phone");
        }


        public void BuildScreen()
        {
            phone.PhoneScreenType = ScreenType.ScreenType_TOUCH_CAPACITIVE;
        }

        public void BuildBattery()
        {
            phone.PhoneBatteryType = BatteryType.MAH_3000;
        }

        public void BuildOS()
        {
            phone.PhoneOS = OperatingSystem.WINDOWS;
        }

        public void BuildStylus()
        {
            phone.PhoneStylus = Stylus.NO;
        }

        public MobilePhone Phone
        {
            get { return phone; }
        }
    }

   //Finally lets have the Director class. 
   //Lets create a Director class that will have the Construct method accepting an IPhoneBuilder and then calling 
   // the respective functions of the ConcreteBuilders internally.

    class Manufacturer
    {
        public void Construct(IPhoneBuilder phoneBuilder) 
        {
            phoneBuilder.BuildBattery();
            phoneBuilder.BuildOS();
            phoneBuilder.BuildStylus();
            phoneBuilder.BuildScreen();

        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a director first
            Manufacturer newManufacturer = new Manufacturer();

            // Create  builder class ready
            IPhoneBuilder phoneBuilder = null;

            phoneBuilder = new AndroidPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n{0} \n", phoneBuilder.Phone.ToString());



            // Now let us create a Windows Phone
            phoneBuilder = new WindowsPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n{0} \n", phoneBuilder.Phone.ToString());

        }
    }
}
