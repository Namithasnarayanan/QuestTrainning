using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCarManagement
{
    internal class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        private List<IDiscountStrategy> discounts = new List<IDiscountStrategy>();

        public void AddItem(string name, int quantity, decimal price)
        {
            var item = items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                item.IncreaseQuantity(quantity);
            }
            else
            {
                items.Add(new CartItem(name, quantity, price));
            }
        }

        public void UpdateItem(string name, int quantity)
        {
            var item = items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                item.UpdateQuantity(quantity);
            }
        }

        public void RemoveItem(string name)
        {
            items.RemoveAll(i => i.Name == name);
        }

        public void ApplyDiscount(IDiscountStrategy discount)
        {
            discounts.Add(discount);
        }

        public decimal CalculateTotal()
        {
            var subtotal = items.Sum(item => item.TotalPrice());
            var totalDiscount = discounts.Sum(discount => discount.Calculate(subtotal));
            return subtotal - totalDiscount;
        }

        public override string ToString()
        {
            var itemsStr = string.Join(Environment.NewLine, items);
            var total = CalculateTotal();
            return $"Cart Items:\n{itemsStr}\nTotal: {total:C}";
        }
    }
}
