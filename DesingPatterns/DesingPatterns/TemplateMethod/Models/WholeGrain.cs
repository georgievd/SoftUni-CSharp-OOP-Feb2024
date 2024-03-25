namespace TemplateMethod.Models
{
    internal class WholeGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Mixing whole grain flour with water and other stuff.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the WholeGrain Bread. It will take 45 minutes");
        }

        public override void Slice()
        {
           Console.WriteLine("This type of bread will not be sliced!");
        }
    }
}
