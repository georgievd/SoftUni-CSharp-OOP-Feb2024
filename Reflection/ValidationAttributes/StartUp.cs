using System;
using ValidationAttributes.Model;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            var person1 = new Person
            (
                "Pesho",
                12
            );

            bool isValidEntity = Validator.IsValid(person);
            bool isValid2 = Validator.IsValid(person1);


            Console.WriteLine(isValidEntity);
            Console.WriteLine(isValid2);
        }
    }
}
