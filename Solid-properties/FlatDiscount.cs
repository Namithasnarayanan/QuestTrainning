using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    public class FlatDiscount : IDiscountStrategy
    {
        private decimal amount;

        public FlatDiscount(decimal amount)
        {
            this.amount = amount;
        }

        public decimal Calculate(decimal subtotal)
        {
            return amount;
        }
    }
}
