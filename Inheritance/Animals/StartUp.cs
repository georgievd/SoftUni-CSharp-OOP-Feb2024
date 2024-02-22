using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           // Examples();

           string animalType;
           while ((animalType = Console.ReadLine()) != "Beast!")
           {
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (animalType == "Dog")
                    {
                        var doggy = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(doggy.GetType().Name);
                        Console.WriteLine(doggy);
                        Console.WriteLine(doggy.ProduceSound());
                    }
                    if (animalType == "Cat")
                    {
                        var cato = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(cato.GetType().Name);
                        Console.WriteLine(cato);
                        Console.WriteLine(cato.ProduceSound());
                    }
                    if (animalType == "Frog")
                    {
                        var froggy = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(froggy.GetType().Name);
                        Console.WriteLine(froggy);
                        Console.WriteLine(froggy.ProduceSound());
                    }

                    if (animalType == "Kitten")
                    {
                        var kitten = new Kitten(animalData[0], int.Parse(animalData[1]));
                        Console.WriteLine(kitten.GetType().Name);
                        Console.WriteLine(kitten);
                        Console.WriteLine(kitten.ProduceSound());
                    }

                    if (animalType == "Tomcat")
                    {
                        var tomcat = new Tomcat(animalData[0], int.Parse(animalData[1]));
                        Console.WriteLine(tomcat.GetType().Name);
                        Console.WriteLine(tomcat);
                        Console.WriteLine(tomcat.ProduceSound());
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
           }

        }

        private static void Examples()
        {
            List<Animal> list = new List<Animal>();

            var sharo = new Dog("Sharo", 3, "Male");
            list.Add(sharo);
            var kermit = new Frog("Kermit", 3, "Male");
            list.Add(kermit);
            var bella = new Cat("Bella", 4, "Female");
            list.Add(bella);
            var bellaJr = new Kitten("Bella Jr.", 1);
            list.Add(bellaJr);
            var tom = new Tomcat("Tom", 1);
            list.Add(tom);


            foreach (var animal in list)
            {
                Console.WriteLine($"{animal.Name} is a {animal.GetType().Name} says: {animal.ProduceSound()}");
            }
        }
    }
}
