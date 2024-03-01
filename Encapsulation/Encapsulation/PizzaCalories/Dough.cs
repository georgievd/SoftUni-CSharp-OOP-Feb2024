namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCalories = 2.0;
		private readonly string flourType;
		private readonly string backingTechnique;


		public Dough(string flourType, string backingTechnique, double weight)
		{
			Weight = weight;
			FlourType = flourType;
			BackingTechnique = backingTechnique;
		}

		private readonly double weight;

		public double Weight
		{
			get => weight;
			init
			{
				if (value is < 1 or > 200)
				{
					throw new ArgumentException("Dough weight should be in the range [1..200].");
				}
				weight = value;
			}
		}


		public string BackingTechnique
		{
			get => backingTechnique;
			init
			{
				if (value.ToLower() is not ("crispy" or "chewy" or "homemade"))
				{
					throw new ArgumentException("Invalid type of dough.");
                }
				backingTechnique = value;
			}
		}


		public string FlourType
		{
			get => flourType;
			init
			{
				if (value.ToLower() is not ("white" or "wholegrain"))
				{
					throw new ArgumentException("Invalid type of dough.");
                }
				flourType = value;
			}
		}

		public double CaloriesPerGram
		{
			get
			{
				double calsPerGram = BaseCalories;
				if (FlourType.ToLower() == "white")
				{
					calsPerGram *= 1.5;
				}

				switch (backingTechnique.ToLower())
				{
					case "crispy":
						calsPerGram *= 0.9; break;
					case "chewy":
						calsPerGram *= 1.1; break;
				}
				return calsPerGram;
			}
		}
	}
}
