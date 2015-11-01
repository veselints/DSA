namespace Tasks
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    class TestingTasks
    {
        static void Main()
        {
            IList<int> firstInput = new List<int>();

            IList<int> secondInput = new List<int>()
            {
                5, 3, 345, -323232, 3, 3, -3, 6, 6, 6, 6, 7, 7, 7, 7, 6, 7, 8, 5, 7
            };

            IList<int> thirdInput = new List<int>()
            {
                5, 6, 6, 6, 6, 7, 7, 7, 6
            };
            
            // 1. Write a program that reads from the console a sequence of positive integer numbers.
            //var TestReadSequence = ReadAndSortIntegers();
            //foreach (var number in TestReadSequence)
            //{
            //    Console.WriteLine(number);
            //}

            // 2. Write a program that reads N integers from the console and reverses them using a stack.
            //int numberOfLines = 7;
            //ReadAndReverseIntegers(numberOfLines);

            // 4. Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
            IList<int> secondResult = FindLongestSubsequenceOfEqualNumbers(secondInput);
            foreach (var number in secondResult)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            // Checks FindLongestSubsequenceOfEqualNumbers and throws exeption as the input list is empty
            //FindLongestSubsequenceOfEqualNumbers(firstInput);

            // 5. Write a program that removes from given sequence all negative numbers.
            IList<int> testRemoveNegative = RevoveNegativeValues(secondInput);
            foreach (var number in testRemoveNegative)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // 6. Write a program that removes from given sequence all numbers that occur odd number of times.
            IList<int> removedOddOccured = RemoveNumbersThatOccureOddTimes(secondInput);
            foreach (var number in removedOddOccured)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
            IDictionary<int, int> testOccurenciesMethod = FindNumberOfOccurencies(secondInput);
            foreach (var pair in testOccurenciesMethod)
            {
                if (pair.Value != 1)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
                else
                {
                    Console.WriteLine("{0} -> 1 time", pair.Key);
                }
            }
            Console.WriteLine();

            // 8. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
            string majourResultSecond = FindMajorantIfExists(secondInput).ToString();
            string majourResultThird = FindMajorantIfExists(thirdInput).ToString();
            Console.WriteLine(majourResultSecond);
            Console.WriteLine("Majour number is {0}", majourResultThird);
            Console.WriteLine();

            // 9. Using the Queue<T> class write a program to print its first 50 members for given N.
            Queue<int> testSequence = EnqueueFirstMembersAccordingToN(2);
            Console.WriteLine("Number of numbers in the sequence is: {0} :)", testSequence.Count);
            while (testSequence.Count > 0)
            {
                Console.WriteLine(testSequence.Dequeue());
            }

            // 11. Implement the data structure linked list.
            CustomLinkedList<int> CheckCustomLinkedList = new CustomLinkedList<int>(new int[] { 7, 8, 9, 10, 11 });
            Console.WriteLine(CheckCustomLinkedList);
            Console.WriteLine();

            // 12. Implement the ADT stack as auto-resizable array.
            CustomStack<int> testCustomStack = new CustomStack<int>();
            testCustomStack.Push(7);
            testCustomStack.Push(8);
            testCustomStack.Push(9);
            testCustomStack.Push(10);
            testCustomStack.Push(11);
            testCustomStack.Push(12);
            while (testCustomStack.Count > 0)
            {
                Console.WriteLine("CustomStack has {0} members", testCustomStack.Count);
                Console.WriteLine(testCustomStack.Peak());
                testCustomStack.Pop();
            }
            // Checks Pop() method and throws exeption as the stack is empty
            // testCustomStack.Pop();
            Console.WriteLine();

            // 13. Implement the ADT queue as dynamic linked list.
            var testLinkedQueue = new LinkedQueue<int>(new int[] { 7, 8, 9, 10, 11, 43, 56 });
            testLinkedQueue.Enqueue(89);
            testLinkedQueue.Enqueue(66);
            while (testLinkedQueue.Count > 0)
            {
                Console.WriteLine("LinkedQueue has {0} members", testLinkedQueue.Count);
                Console.WriteLine(testLinkedQueue.Dequeue());
            }
            Console.WriteLine();
        }

        // 1. Write a program that reads from the console a sequence of positive integer numbers.
        public static IList<int> ReadSequenceOfPositiveNumbers()
        {
            IList<int> result = new List<int>();

            string currentLine = Console.ReadLine();

            while (currentLine != String.Empty)
            {
                string trimmedResult = currentLine.Trim();
                int number;

                if (int.TryParse(trimmedResult, out number) && number > 0 )
                {
                    result.Add(number);
                }
                else
                {
                    Console.WriteLine("You have given an inalid input");
                }

                currentLine = Console.ReadLine();
            }

            return result;
        }

        // 2. Write a program that reads N integers from the console and reverses them using a stack.
        public static void ReadAndReverseIntegers(int numberOfIntegers)
        {
            Stack<int> result = new Stack<int>();

            while (result.Count < numberOfIntegers)
            {
                string currentLine = Console.ReadLine();
                string trimmedResult = currentLine.Trim();
                int number;

                if (int.TryParse(trimmedResult, out number))
                {
                    result.Push(number);
                }
                else
                {
                    Console.WriteLine("You have given an inalid input");
                }
            }

            while (result.Count > 0)
            {
                Console.WriteLine(result.Pop());
            }
        }

        // 3. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
        public static IList<int> ReadAndSortIntegers()
        {
            List<int> result = new List<int>();

            string currentLine = Console.ReadLine();

            while (currentLine != String.Empty)
            {
                string trimmedResult = currentLine.Trim();
                int number;

                if (int.TryParse(trimmedResult, out number))
                {
                    result.Add(number);
                }
                else
                {
                    Console.WriteLine("You have given an inalid input");
                }

                currentLine = Console.ReadLine();
            }

            result.Sort();

            return result;
        }

        // 4. Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
        public static IList<int> FindLongestSubsequenceOfEqualNumbers(IList<int> inputList)
        {
            ValidateList(inputList);

            int maxNumberOfSubsequent = 1;
            int currentNumberOfSubsequent = 1;
            int endIndex = 0;

            for (int i = 1; i < inputList.Count; i++)
            {
                if (inputList[i] == inputList[i - 1])
                {
                    currentNumberOfSubsequent ++;
                }
                else
                {
                    currentNumberOfSubsequent = 1;
                }

                if (currentNumberOfSubsequent >= maxNumberOfSubsequent)
                {
                    maxNumberOfSubsequent = currentNumberOfSubsequent;
                    endIndex = i;
                }
            }

            IList<int> result = new List<int>();
            for (int i = endIndex - maxNumberOfSubsequent + 1; i <= endIndex; i++)
            {
                result.Add(inputList[i]);
            }

            return result;
        }

        // 5. Write a program that removes from given sequence all negative numbers.
        public static IList<int> RevoveNegativeValues(IList<int> inputList)
        {
            ValidateList(inputList);

            IList<int> result = new List<int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                int currentNumber = inputList[i];
                if (currentNumber >= 0)
                {
                    result.Add(currentNumber);
                }
            }

            return result;
        }

        // 6. Write a program that removes from given sequence all numbers that occur odd number of times.
        private static IList<int> RemoveNumbersThatOccureOddTimes(IList<int> inputList)
        {
            IDictionary<int, int> nubersAndOccurencies = FindNumberOfOccurencies(inputList);

            IList<int> result = new List<int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                int currentNumber = inputList[i];
                int numberOfOccurencies = nubersAndOccurencies[currentNumber];
                if (numberOfOccurencies % 2 == 0)
                {
                    result.Add(currentNumber);
                }
            }

            return result;
        }

        // 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
        private static IDictionary<int, int> FindNumberOfOccurencies(IList<int> inputList)
        {
            ValidateList(inputList);

            IDictionary<int, int> nubersAndOccurencies = new Dictionary<int, int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                int currentNumber = inputList[i];
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

        // 8. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
        public static object FindMajorantIfExists(IList<int> inputList)
        {
            IDictionary<int, int> numberOfOccurencies = FindNumberOfOccurencies(inputList);

            var mostlyOccuredPair = numberOfOccurencies
                .OrderBy(k => k.Value)
                .LastOrDefault();

            if (mostlyOccuredPair.Value >= inputList.Count / 2 + 1)
            {
                return mostlyOccuredPair.Key;
            }

            return "This sequence has no major!";
        }

        // 9. Using the Queue<T> class write a program to print its first 50 members for given N.
        public static Queue<int> EnqueueFirstMembersAccordingToN(int startNumber, int numberOfMembers = 50)
        {
            int currentNumber = startNumber;
            Queue<int> result = new Queue<int>();
            Queue<int> intermediateResult = new Queue<int>();
            result.Enqueue(currentNumber);

            while (result.Count < numberOfMembers)
            {
                if (result.Count > 1)
                {
                    intermediateResult.Enqueue(currentNumber);
                }

                result.Enqueue(currentNumber + 1);
                intermediateResult.Enqueue(currentNumber + 1);
                if (result.Count == numberOfMembers)
                {
                    break;
                }

                result.Enqueue(2 * currentNumber + 1);
                intermediateResult.Enqueue(2 * currentNumber + 1);
                if (result.Count == numberOfMembers)
                {
                    break;
                }

                result.Enqueue(currentNumber + 2);
                intermediateResult.Enqueue(currentNumber + 2);

                currentNumber = intermediateResult.Dequeue();
            }

            return result;
        }

        // TODO: Task 10 -> not implemented

        // Helper method
        private static void ValidateList(IList<int> inputList)
        {
            if (inputList.Count < 1)
            {
                throw new ArgumentNullException("The given list should contain at least one number.");
            }
        }
    }
}
