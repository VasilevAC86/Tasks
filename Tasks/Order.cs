using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Order:IOrder
    {
        protected List<OrderItem> items_ = new List<OrderItem>();
        public void AddProduct(Product product, int quantity)
        {
            var existingItem = items_.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem.Product.Id != 0)
            {
                items_.Remove(existingItem);
                existingItem.Quantity += quantity;
                items_.Add(existingItem);
            }
            else
                items_.Add(new OrderItem { Quantity = quantity, Product = product });
        }
        public void RemoveProduct(int id)
        {
            items_.RemoveAll(i => i.Product.Id == id);
        }
        public decimal GetTotalPrice()
        {
            return items_.Sum(i => i.Product.Price * i.Quantity);
        }
        public List<OrderItem> GetOrderItems() { return items_; }
    }
}
