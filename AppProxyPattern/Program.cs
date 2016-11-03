using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppProxyPattern
{
    interface IActualPrices
    {
        string GoldPrice
        {
            get;
        }
        string SilverPrice
        {
            get;
        }
        string DollarToRupee
        {
            get;
        }
        
    }
    class clsActualPrices : IActualPrices
    {

        public string GoldPrice
        {
            get {return "30500";}
        }

        public string SilverPrice
        {
            get {return "300";}
        }

        public string DollarToRupee
        {
            get { return "67"; }
        }
    }
    class clsActualPricesProxy : IActualPrices 
    {

        public string GoldPrice
        {
            get { return GetResponseFromServer("g"); }
        }

        public string SilverPrice
        {
            get { return GetResponseFromServer("g"); }
        }

        public string DollarToRupee
        {
            get { return GetResponseFromServer("g"); }
        }
        private string GetResponseFromServer(string input)
        {
            string result = string.Empty;
            using (TcpClient client = new TcpClient())
            {
                client.Connect("127.0.0.1", 9999);

                Stream stream = client.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(input.ToCharArray());

                stream.Write(ba, 0, ba.Length);

                byte[] br = new byte[100];
                int k = stream.Read(br, 0, 100);



                for (int i = 0; i < k; i++)
                {
                    result += Convert.ToChar(br[i]);
                }

                client.Close();
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IActualPrices proxy = new clsActualPricesProxy();

            Console.WriteLine("Gold Price: ");
            Console.WriteLine(proxy.GoldPrice);

            Console.WriteLine("Silver Price: ");
            Console.WriteLine(proxy.SilverPrice);

            Console.WriteLine("Dollar to Ruppe Conversion: ");
            Console.WriteLine(proxy.DollarToRupee);
        }
    }
}
