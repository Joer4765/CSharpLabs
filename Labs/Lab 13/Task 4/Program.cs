namespace Task_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var product1 = Tuple.Create("Яблуко", 10, "Фрукти", 0.2);
            var product2 = Tuple.Create("Банан", 15, "фрукти", 0.3);
            var product3 = Tuple.Create("Молоко", 25, "Молочні продукти", 1.0);

            var products = new List<Tuple<string, int, string, double>> { product1, product2, product3 };

            Console.WriteLine(SocialProducts(products));
        }
        
        // public static Tuple<> Create()

        public static int SocialProducts(List<Tuple<string, int, string, double>> products)
        {
            var averagePrice = products.Average(product => product.Item2);
            var socialProducts = products.Where(product => product.Item2 < averagePrice).ToList();
            return socialProducts.Count;
        }
    }

    public class Product(string name, int price, string type, int demand)
    {
        private Tuple<string, int, string, double> _product = Tuple.Create("Яблуко", 10, "Фрукти", 0.2);
    }
}