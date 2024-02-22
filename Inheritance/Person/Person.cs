using System;

namespace Person
{
    public class Person
    {
        // 1. Add Fields
        private int age;

        // 2. Add Constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // 3. Add Properties

        public string Name { get; set; }

        public virtual int Age
        {
            get => age;
            set
            {
                if (value < 0)
                { 
                   // age = 0;
                    throw new ArgumentException("Age cannot be lower than 0");
                }

                age = value;

            }
        }

        // 4. Add Methods

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
