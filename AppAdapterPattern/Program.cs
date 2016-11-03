using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdapterPattern
{
    interface ITarget 
    {
        List<string> GetAllProducts();
    }
    public class VendorAdaptee
    {
        public List<string> GetAllVendorProducts() 
        {
            List<string> collProduct = new List<string>();
            collProduct.Add("Gaming Consoles");
            collProduct.Add("TV");
            collProduct.Add("Camera");
            collProduct.Add("Fridge");
            collProduct.Add("washing machine");
            collProduct.Add("computer");
            collProduct.Add("laptop");

            return collProduct;
        }
    }
    public class VendorAdaptor : ITarget 
    {
        public List<string> GetAllProducts()
        {
            VendorAdaptee adaptee = new VendorAdaptee();
            return adaptee.GetAllVendorProducts();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new VendorAdaptor();
            List<string> products = target.GetAllProducts();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
    }
}
