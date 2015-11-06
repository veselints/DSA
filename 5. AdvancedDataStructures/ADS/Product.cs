namespace ADS
{
    using System;

    public class Product : IComparable
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            Product another = (obj)as Product;
            return (int)(this.Price - another.Price);
        }
    }
}
