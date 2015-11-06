using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DsEfficiency
{
    public class Student : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string fn, string ln)
        {
            this.FirstName = fn;
            this.LastName = ln;
        }

        public int CompareTo(object obj)
        {
            var anotherAsStudent = (Student)obj;
            string thisName = this.LastName + this.FirstName;
            string otherName = anotherAsStudent.LastName + anotherAsStudent.FirstName;
            return thisName.CompareTo(otherName);
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
