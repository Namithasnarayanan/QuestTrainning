using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    public class BuyOneGetOneDiscount : IDiscountStrategy
    {
        private string itemName;

        public BuyOneGetOneDiscount(string itemName)
        {
            this.itemName = itemName;
        }

        public decimal Calculate(decimal subtotal)
        {
            
            return 0; 
        }
    }

}