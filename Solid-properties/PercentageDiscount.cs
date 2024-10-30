using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    public class PercentageDiscount
    {
        private decimal percentage;

        public PercentageDiscount(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal Calculate(decimal subtotal)
        {
            return subtotal * (percentage / 100);
        }
    }
}
