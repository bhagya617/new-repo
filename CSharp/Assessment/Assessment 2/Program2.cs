using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    public class Product
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public double price { get; set; }
        public Product(int prodid, string prodname, double p)
        {
            productid = prodid;
            productname = prodname;
            price = p;


        }

    }
    public class PriceComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null || y == null)
                throw new ArgumentException("both are null");
            if (x.price > y.price)
                return 1;
            else if (x.price < y.price)
                return -1;
            else
                return 0;

        }

    }
    public class program
    {


        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            int i;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter the product details for product{i + 1}");
                Console.WriteLine("Enter the ID");
                int prodid = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the product name");
                string prodname = Console.ReadLine();
                Console.WriteLine("enter the price of product");
                double p = double.Parse(Console.ReadLine());
                products.Add(new Product(prodid, prodname, p));
            }
            products.Sort(new PriceComparer());
            Console.WriteLine("\nproducts sorted by price ");
            foreach (var product in products)
            {

                Console.WriteLine($"\nProductID={product.productid},product name:{product.productname},price:{product.price}");
            }

        }
    }
}
}