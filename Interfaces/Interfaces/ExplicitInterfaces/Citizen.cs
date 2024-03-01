using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public string Name { get; }

        public int Age { get; }

        public string Country { get; }

        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        string IPerson.GetName()
        {
            return Name;
        }

    }
}
