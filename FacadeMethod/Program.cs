using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderFacade orderFacade = new OrderFacade();
            List<Basket> products = new List<Basket>
            {
                new Basket{ Id=1, ProductName="X", Price=5, Quantity=2},
                new Basket{ Id=2, ProductName="Y", Price=8, Quantity=3},
                new Basket{ Id=1, ProductName="Z", Price=10, Quantity=1},
                new Basket{ Id=1, ProductName="Q", Price=20, Quantity=1}
            };

            orderFacade.Order("Gökhan", "Aras Kargo", products);
            Console.ReadLine();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Basket
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cargo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
    }

    public class OrderManager
    {
        public int AddOrder(DateTime orderDate, Customer customer, Cargo cargo)
        {
            Console.WriteLine("{0} tarihinde {1} isimli müşteri siparişi eklendi. Seçilen kargo şirketi:{2} ", orderDate.ToString(), customer.Name,cargo.Name);
            return 1;
        }
    }

    public class OrderDetails
    {
        public void AddOrderDetail(int orderId,List<Basket> products)
        {
            Console.WriteLine("{0} numaralı siparişte alınan ürünler:", orderId);
            Console.WriteLine("...............................");
            products.ForEach(u => Console.WriteLine("{0} ürününden {1} adet alındı. Ara toplam:{2}", u.ProductName, u.Quantity, u.Quantity * u.Price));
            Console.WriteLine("...............................");
            var total = products.Sum(x => x.Price * x.Quantity);
            Console.WriteLine("Toplam:{0}", total);
        }
    }

    public class ProductManager
    {
        public void StockUpdate(int productId, int quantity)
        {
            Console.WriteLine("{0} id'li ürünün stoğundan, {1} adet düşüldü.", productId, quantity);
        }
    }

    public class OrderFacade
    {
        private Customer _customer;
        private Cargo _cargo;
        private ProductManager _productManager = new ProductManager();
        private OrderManager _orderManager = new OrderManager();
        private OrderDetails _orderDetails = new OrderDetails();


        public void Order(string customerName, string cargoName, List<Basket> products)
        {
            _customer = new Customer { Name = customerName };
            _cargo = new Cargo { Name = cargoName };
            int orderId = _orderManager.AddOrder(DateTime.Now, _customer, _cargo);
            _orderDetails.AddOrderDetail(orderId, products);
            products.ForEach(u => _productManager.StockUpdate(u.Id, u.Quantity));
            Console.WriteLine();
            Console.WriteLine("İşlem tamamlandı");
        }
    }
}
