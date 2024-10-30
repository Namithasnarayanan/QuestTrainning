using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    internal class CartItem
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public CartItem(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public decimal TotalPrice()
        {
            return Quantity * Price;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Quantity} x {Name} @ {Price:C} each";
        }
    }
}
