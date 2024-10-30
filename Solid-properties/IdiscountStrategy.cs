using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    internal interface IDiscountStrategy
    {
        decimal Calculate(decimal subtotal);
    }
}
