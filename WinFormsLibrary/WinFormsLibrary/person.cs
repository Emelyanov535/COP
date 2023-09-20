using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Height { get; private set; }

        public Person()
        {
        }

        public Person(string name, int age, int height)
        {
            Name = name;
            Age = age;
            Height = height;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Height: {Height}";
        }
    }
}
