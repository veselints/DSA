using System;
using System.Collections.Generic;
using System.Text;

namespace JediMeditationSolution
{
    class Program
    {
        static void Main()
        {
            string stringNumberOfJedi = Console.ReadLine().Trim();
            int numberOfJedi = int.Parse(stringNumberOfJedi);

            var mastersList = new LinkedList<string>();
            var knightsList = new LinkedList<string>();
            var padawansList = new LinkedList<string>();

            char[] separator = {' '};
            string[] jedi = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numberOfJedi; i++)
            {
                var currentJedi = jedi[i];
                switch (currentJedi[0])
                {
                    case 'm':
                        mastersList.AddLast(currentJedi);
                        break;
                    case 'k':
                        knightsList.AddLast(currentJedi);
                        break;
                    case 'p':
                        padawansList.AddLast(currentJedi);
                        break;
                }
            }

            StringBuilder sb = new StringBuilder();
            int mastersCount = mastersList.Count;
            for (int i = 0; i < mastersCount; i++)
            {
                sb.Append(mastersList.First.Value);
                sb.Append(' ');
                mastersList.RemoveFirst();
            }
            int knightsCount = knightsList.Count;
            for (int i = 0; i < knightsCount; i++)
            {
                sb.Append(knightsList.First.Value);
                sb.Append(' ');
                knightsList.RemoveFirst();
            }
            int padawansCount = padawansList.Count;
            for (int i = 0; i < padawansCount; i++)
            {
                sb.Append(padawansList.First.Value);
                sb.Append(' ');
                padawansList.RemoveFirst();
            }

            string result = sb.ToString();

            Console.WriteLine(result);
        }
    }
}
