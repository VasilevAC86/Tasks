namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 1000m });
            store.AddProduct(new Product { Id = 2, Name = "Phone", Price = 500m });
            var order = new CustomerOrder
            {
                CustomerName = "Вася",
                CustomerAddress = "123 Ирбитская",
                CustomerPhone = "55-55-55"
            };
            var laptop = store.FindProductByName("Laptop").FirstOrDefault();
            var phone = store.FindProductByName("Phone").FirstOrDefault();
            // Сохраним заказ
            store.AddOrder(order);
            Console.WriteLine(JsonHelper.SerializedObj(order));
            JsonHelper.SaveToFile(order, "order.json");

            var loaderOrder = JsonHelper.LoadFromFile<CustomerOrder>("order.json");
            Console.WriteLine("\nLoaded Order:");
            Console.WriteLine("Customer: " + loaderOrder.CustomerName);
            Console.WriteLine("Total Price: " + loaderOrder.GetTotalPrice());
            // Поиск заказов клиента
            var cutomerOrders = store.GetOrdersByCustomerName("Вася");
            Console.WriteLine("\nOrders for Вася:");
            foreach (var custOrder in cutomerOrders)
            {
                Console.WriteLine("Order total: " + custOrder.GetTotalPrice());
            }
        }
    }
}
