namespace TemplateMethod.Models
{
    internal class WhiteBread : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Mixing white flour with water and other stuff.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the White Bread. It will take 30 minutes");
        }
    }
}
