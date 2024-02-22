using System;

namespace Animals
{
    public abstract class Animal
    {
		private string name;

		private int age;

		private string gender;

		protected Animal(string name, int age, string gender)
		{
			Name = name;
			Age = age;
			Gender = gender;
		}

		public string Gender
		{
			get => gender;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Invalid Input!");
				}
				gender = value;
			}
		}

		public int Age
		{
			get => age;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Invalid Input!");
				}
                age = value;
			}
		}

		public string Name
		{
			get => name;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Invalid Input!");
				}
                name = value;
			}
		}

		public override string ToString()
		{
			return $"{Name} {Age} {Gender}";
		}

		/// <summary>
		/// Abstract methods have no default implementation.
		/// They must be implemented in child classes.
		/// </summary>
		/// <returns></returns>
		public abstract string ProduceSound();

    }
}
