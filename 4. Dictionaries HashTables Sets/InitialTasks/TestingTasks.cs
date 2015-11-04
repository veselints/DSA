namespace InitialTasks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class TestingTasks
    {
        static void Main()
        {
            //IList<object> firstInput = new List<object>();

            //IList<object> secondInput = new List<object>()
            //{
            //    5.5, 3.487362, 345.0, -323232, 3, 3, -3, 6.7, 6, 6, 6, 7, 7, 7, 7, 6, 7, 8.909, 5, 7
            //};

            //IList<object> thirdInput = new List<object>()
            //{
            //    5.4, 6.6, 6.6, 6.6, 6.7, 7.6, 7.6, 7, 6.5
            //};

            //IList<object> stringInput = new List<object>()
            //{
            //    "C#", "SQL", "PHP", "PHP", "SQL", "SQL"
            //};
            
            
            //// 1. Write a program that counts in a given array of double values the number of occurrences of each value.
            //// This checks if the validation is ok
            //// It should throw exeption
            ////var numberOfOccurrenciesCrash = FindNumberOfOccurencies(firstInput);
            ////Console.WriteLine();

            //var numberOfOccurrencies = FindNumberOfOccurencies(secondInput);
            //foreach (var pair in numberOfOccurrencies)
            //{
            //    if (pair.Value != 1)
            //    {
            //        Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0} -> 1 time", pair.Key);
            //    }
            //}
            //Console.WriteLine();

            //// 2. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.
            //IList<object> oddlyOccuredStrings = ExtractPresentedOddNumberOfTimes(stringInput);
            //foreach (var text in oddlyOccuredStrings)
            //{
            //    Console.WriteLine(text);
            //}
            //Console.WriteLine();

            //// 3. Write a program that counts how many times each word from given text file words.txt appears in it.
            //string filepath = "../../text.txt";
            //IList<KeyValuePair<string, int>> countedInText = CountWordNumberInText(filepath);
            //Console.OutputEncoding = Encoding.UTF8;
            //foreach (var pair in countedInText)
            //{
            //    if (pair.Value != 1)
            //    {
            //        Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0} -> 1 time", pair.Key);
            //    }
            //}
            //Console.WriteLine();

            var testHashTable = new CustomHashTable<int, string>();
            testHashTable.Add(7, "ebalosie");
            testHashTable.Add(8, "tuionui");
            testHashTable.Add(9, "mamata");
            testHashTable.Add(10, "tintirimitiri");
            testHashTable.Add(23, "ebadsadasdalosie");

            foreach (var pair in testHashTable)
            {
                Console.WriteLine("Key: {0} -> Value: {1}", pair.Key, pair.Value);
            }
        }

        

        

        // 1. Write a program that counts in a given array of double values the number of occurrences of each value.
        private static IDictionary<object, int> FindNumberOfOccurencies(IList<object> inputList)
        {
            ValidateList(inputList);

            IDictionary<object, int> nubersAndOccurencies = new Dictionary<object, int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                object currentNumber = inputList[i];
                if (nubersAndOccurencies.ContainsKey(currentNumber))
                {
                    nubersAndOccurencies[currentNumber]++;
                }
                else
                {
                    nubersAndOccurencies[currentNumber] = 1;
                }
            }

            return nubersAndOccurencies;
        }

        // 2. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.
        private static IList<object> ExtractPresentedOddNumberOfTimes(IList<object> inputList)
        {
            var numberOFAllObjects = FindNumberOfOccurencies(inputList);

            IList<object> result = new List<object>();

            foreach (var pair in numberOFAllObjects)
            {
                if (pair.Value % 2 == 1)
                {
                    result.Add(pair.Key);
                }
            }

            return result;
        }

        // 3. Write a program that counts how many times each word from given text file words.txt appears in it.
        private static IList<KeyValuePair<string, int>> CountWordNumberInText(string filepath)
        {
            TextReader reader = new StreamReader(filepath, Encoding.Default);
            var translatedContent = reader.ReadToEnd();
            reader.Close();

            char[] splittingChars = new[] { ',', ' ', '.', '!', '?', '\r', '\n', '-', '\"', '(', ')', '/', ':', '\t', ';', '„', '“' };
            var splittedText = translatedContent.Split(splittingChars, StringSplitOptions.RemoveEmptyEntries);

            IDictionary<string, int> stringsAndOccurencies = new Dictionary<string, int>();
            for (int i = 0; i < splittedText.Length; i++)
            {
                var currentWord = splittedText[i].ToLower();
                if (stringsAndOccurencies.ContainsKey(currentWord))
                {
                    stringsAndOccurencies[currentWord]++;
                }
                else
                {
                    stringsAndOccurencies[currentWord] = 1;
                }
            }

            var result = stringsAndOccurencies.OrderBy(p => p.Value).ToList();

            return result;
        }


        // Helper method
        private static void ValidateList(IList<object> inputList)
        {
            if (inputList.Count < 1)
            {
                throw new ArgumentNullException("The given list should contain at least one number.");
            }
        }
    }
}
