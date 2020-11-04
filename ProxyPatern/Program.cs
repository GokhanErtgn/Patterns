using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceProxy productService = new ProductServiceProxy();
            var nameList=productService.GetNameByProductList();

            nameList.ForEach(Print);


            nameList.ForEach(delegate (String name)
            {
                Console.WriteLine(name);
            });

            void Print(string s)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();

        }

        
    }

    public interface IProductService
    {
        List<string> GetNameByProductList();
    }

    public class ProductService : IProductService
    {
        public List<string> GetNameByProductList()
        {
            return new List<string>() { "Saat", "Gömlek", "Tirbuşon" };
        }
    }

    public class ProductServiceProxy : IProductService
    {
        //Dikkat: işi yapacak olan gerçek nesne, bir "alan" olarak tanımlandı:
        private ProductService productService = null;
        public List<string> GetNameByProductList()
        {
            //proxy nesnemizin bu metodu, gerçek nesnenin aynı metodunu çağıracak: 
            productService = new ProductService();
            return productService.GetNameByProductList();
        }
    }

}
