namespace ADS
{
    using System;
    using Wintellect.PowerCollections;

    public class AppStart
    {
        static void Main()
        {
            // Testing priority queue
            var testQue = new PriorityQueue<int>();
            testQue.Enque(1);
            testQue.Enque(5);
            testQue.Enque(-87);
            testQue.Enque(67);
            testQue.Enque(98);
            testQue.Enque(6765);
            testQue.Enque(12);
            testQue.Enque(1);
            testQue.Enque(-2);
            testQue.Enque(-5);
            testQue.Enque(1);
            testQue.Enque(1);
            testQue.Enque(231);
            testQue.Enque(11);

            int numberOfEntries = testQue.Count;
            for (int i = 0; i < numberOfEntries -1; i++)
            {
                Console.WriteLine(testQue.Dequeue());
            }


            // Testing products task
            OrderedBag<Product> tryBag = new OrderedBag<Product>();
            tryBag.Add(new Product("Mlqko", 55.76M));
            tryBag.Add(new Product("Hlqb", 56M));
            tryBag.Add(new Product("Maslo", .6M));
            tryBag.Add(new Product("Kroasan", 5.76M));
            tryBag.Add(new Product("Biskviti", 5.76M));
            tryBag.Add(new Product("Zele", 355.76M));
            tryBag.Add(new Product("Fystyci", 765.76M));
            tryBag.Add(new Product("Shokolad", 1.76M));

            var fromRangeProduct = new Product("test", 5m);

            var currentView = tryBag.RangeFrom(fromRangeProduct, true);

            foreach (var product in currentView)
            {
                Console.WriteLine("{0} has price of -> {1}", product.Name, product.Price);
            }



        }
    }
}
