using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public interface IOrder
    {
        void AddProduct(Product product, int quantity);
        void RemoveProduct(int id);
        decimal GetTotalPrice();
    }
}
