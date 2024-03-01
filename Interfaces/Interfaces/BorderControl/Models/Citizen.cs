namespace BorderControl.Models
{
    public class Citizen : BaseEntity
    {
        public int Age { get; private set; }
        public string Name { get; set; }

        public Citizen(string id, int age, string name)
        {
            Id = id;
            Age = age;
            Name = name;
        }
    }
}
