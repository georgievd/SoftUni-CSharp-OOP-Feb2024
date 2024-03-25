using Prototype.Interfaces;

namespace Prototype.Models
{
    public class Student : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

        public int[] Grades { get; set; }

        public Student(string firstName, string lastName, DateTime doB)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} born on {DoB}. Grades: {string.Join(',', Grades)}";
        }

        public object Clone()
        {
            // This does shallow copy. Copies values of values types.
            // Reference types are passed by reference
            Student temp = (Student)MemberwiseClone();

            // We need to handle the referent types 
            temp.Grades = new int[Grades.Length];
            for (int i = 0; i < Grades.Length; i++)
            {
                temp.Grades[i] = this.Grades[i];
            }
            return temp;
        }
    }
}
