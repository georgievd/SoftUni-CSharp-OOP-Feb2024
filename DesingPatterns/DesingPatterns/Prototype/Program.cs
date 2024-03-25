using Prototype.Models;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student pesho = new Student("Pesho", "Petrov", new DateTime(1992, 12, 10));
            pesho.Grades = new int[] { 6, 6, 6, 6 };


            //Student ivan = pesho;
            //ivan.FirstName = "Ivan";  

            Student ivan = (Student) pesho.Clone();

            ivan.FirstName = "Ivan";
            ivan.Grades[0] = 2;
            ivan.Grades[3] = 2;

            Console.WriteLine($"Pesho: {pesho}");   
            Console.WriteLine($"Ivan: {ivan}");   
        }
    }
}
