using TemplateMethod.Models;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
           WhiteBread whiteBread = new WhiteBread();
           whiteBread.Make();

           WholeGrain wholeGrain = new WholeGrain();
           wholeGrain.Make();
        }
    }
}
