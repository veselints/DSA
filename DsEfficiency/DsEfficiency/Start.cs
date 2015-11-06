using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsEfficiency
{
    class Start
    {
        static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            var coursesDictionary = new SortedDictionary<string, SortedSet<Student>>();

            for (int i = 0; i < numberOfRows; i++)
            {
                var currentLine = Console.ReadLine();
                var entry = currentLine.Split('|');
                var currentStudent = new Student(entry[0].Trim(), entry[1].Trim());
                var currentCourse = entry[2].Trim();

                if (!coursesDictionary.ContainsKey(currentCourse))
                {
                    coursesDictionary[currentCourse] = new SortedSet<Student>();
                }

                coursesDictionary[currentCourse].Add(currentStudent);
            }

            foreach (var pair in coursesDictionary)
            {
                var result = string.Join(", ", pair.Value);
                Console.WriteLine("{0}: {1}", pair.Key, result);
            }
        }
    }
}
