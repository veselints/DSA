using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace OnlineStore
{
    public class Product : IComparable
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string producer, decimal price)
        {
            this.Price = price;
            this.Producer = producer;
            this.Name = name;
        }

        public override string ToString()
        {
            return String.Format("{{{0};{1};{2}}}", this.Name, this.Producer, string.Format("{0:F2}", this.Price));
        }

        public int CompareTo(object obj)
        {
            var another = (Product)obj;
            return this.ToString().CompareTo(another.ToString());
        }
    }

    public class OnlineStore
    {
        private static Dictionary<decimal, OrderedBag<Product>> productsByPrice = new Dictionary<decimal, OrderedBag<Product>>();
        private static Dictionary<string, OrderedBag<Product>> productsByName = new Dictionary<string, OrderedBag<Product>>();
        private static Dictionary<string, OrderedBag<Product>> productsByProducer = new Dictionary<string, OrderedBag<Product>>();

        private const string AddedMessage = "Product added";
        private const string NotFoundMessage = "No products found";
        private const string DeletedMessage = "{0} products deleted";


        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string stringCommand = Console.ReadLine();

                int indexOfFirstBlankSpace = stringCommand.IndexOf(" ");
                string command = stringCommand.Substring(0, indexOfFirstBlankSpace);
                string parameters = stringCommand.Substring(indexOfFirstBlankSpace + 1);
                var parametersArray = parameters.Split(';');

                switch (command)
                {
                    case "AddProduct": AddProduct(parametersArray[0], parametersArray[2], parametersArray[1]);
                        break;
                    case "DeleteProducts":
                        if (parametersArray.Length == 2)
                        {
                            Delete(parametersArray[1], parametersArray[0]);
                        }
                        else
                        {
                            Delete(parameters);
                        }
                        break;
                    case "FindProductsByName": FindByName(parameters);
                        break;
                    case "FindProductsByProducer": FindByProducer(parameters);
                        break;
                    case "FindProductsByPriceRange": FindByPrice(parametersArray[0], parametersArray[1]);
                        break;

                }
            }

        }

        private static void AddProduct(string name, string producer, string stringPrice)
        {
            var price = decimal.Parse(stringPrice);
            var currentProduct = new Product(name, producer, price);

            if (!productsByName.ContainsKey(name))
            {
                productsByName[name] = new OrderedBag<Product>();
            }
            productsByName[name].Add(currentProduct);

            if (!productsByProducer.ContainsKey(producer))
            {
                productsByProducer[producer] = new OrderedBag<Product>();
            }
            productsByProducer[producer].Add(currentProduct);

            if (!productsByPrice.ContainsKey(price))
            {
                productsByPrice[price] = new OrderedBag<Product>();
            }
            productsByPrice[price].Add(currentProduct);

            Console.WriteLine(AddedMessage);
        }

        private static void Delete(string producer)
        {
            var productsToBeDeleted = productsByProducer[producer];
            if (productsToBeDeleted.Count == 0)
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            foreach (var product in productsToBeDeleted)
            {
                productsByName[product.Name].Remove(product);
                productsByPrice[product.Price].Remove(product);
            }

            productsByProducer.Remove(producer);
            Console.WriteLine(DeletedMessage, productsToBeDeleted.Count);
        }

        private static void Delete(string producer, string name)
        {
            var nameProductsToBeDeleted = productsByName[name];
            if (nameProductsToBeDeleted.Count == 0)
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            var productsToBeRemoved = new List<Product>();

            foreach (var product in nameProductsToBeDeleted)
            {
                if (product.Producer == producer)
                {
                    productsToBeRemoved.Add(product);
                }
            }

            if (productsToBeRemoved.Count == 0)
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            foreach (var product in productsToBeRemoved)
            {
                productsByName[product.Name].Remove(product);
                productsByProducer[product.Producer].Remove(product);
                productsByPrice[product.Price].Remove(product);
            }

            Console.WriteLine(DeletedMessage, productsToBeRemoved.Count);
        }

        private static void FindByName(string name)
        {
            if (!productsByName.ContainsKey(name))
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }
            OrderedBag<Product> found = productsByName[name];

            if (found.Count == 0)
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            foreach (var product in found)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private static void FindByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            OrderedBag<Product> found = productsByProducer[producer];

            if (found.Count == 0)
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            foreach (var product in found)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private static void FindByPrice(string stringStartPrice, string stringEndPrice)
        {
            var startPrice = decimal.Parse(stringStartPrice);
            var endPrice = decimal.Parse(stringEndPrice);
            
            var found = productsByPrice
                .Where(x => x.Key >= startPrice && x.Key<= endPrice)
                .SelectMany(x => x.Value)
                .OrderBy(x => x.ToString());
            
            if (found.Count() == 0)
            {
                Console.WriteLine(NotFoundMessage);
                return;
            }

            foreach (var product in found)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
