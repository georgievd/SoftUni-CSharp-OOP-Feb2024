using Composite.Models;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleGift toyTruck = new SingleGift("Toy Truck", 9.99m);
            SingleGift toySoldier = new SingleGift("Toy Soldier", 12.50m);
            SingleGift barbieDoll = new SingleGift("Barbie Doll", 15.99m);

            GiftBox plainBox = new GiftBox("Plain Box", 0);
            plainBox.Add(toyTruck);
            plainBox.Add(toySoldier);

            GiftBox fancyShinyBox = new GiftBox("Fancy and Shiny Box", 10m);
            fancyShinyBox.Add(plainBox);
            fancyShinyBox.Add(barbieDoll);

            Console.WriteLine(fancyShinyBox);

        }
    }
}
