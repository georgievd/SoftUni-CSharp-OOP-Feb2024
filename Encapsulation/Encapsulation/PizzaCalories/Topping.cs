namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCalories = 2.0;
		private readonly string toppingType;
		private readonly double weight;

		public double Weight
		{
			get => weight;
			init
			{
				if (value is < 1 or > 50)
				{
					throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
				}
				weight = value;
			}
		}


		public Topping(string toppingType, double weith)
		{
			Weight = weith;
			ToppingType = toppingType;
		}

		public string ToppingType
		{
			get => toppingType;
			init
			{
				if (value.ToLower() is not ("meat" or "veggies" or "cheese" or "sauce"))
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}
				toppingType = value;
			}
        }

		public double CalculateCaloriesPerGram()
		{
			return ToppingType.ToLower() switch
			{
				"meat" => BaseCalories * 1.2,
				"veggies" => BaseCalories * 0.8,
				"cheese" => BaseCalories * 1.1,
				"sauce" => BaseCalories * 0.9
			};
		}

    }
}
