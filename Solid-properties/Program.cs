using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();

            
            cart.AddItem("Laptop", 1, 1200);
            cart.AddItem("Mouse", 2, 25);

            
            //cart.ApplyDiscount(new PercentageDiscount(10));  
            cart.ApplyDiscount(new FlatDiscount(50));         
            cart.ApplyDiscount(new BuyOneGetOneDiscount("Mouse"));  

            
            Console.WriteLine(cart);
        }
    }
}