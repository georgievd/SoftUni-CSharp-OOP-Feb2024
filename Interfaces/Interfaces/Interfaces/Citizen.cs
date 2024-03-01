namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Id
        {
            get;
            private set;
        }

        public string Birthdate
        {
            get;
            private set;
        }
    }
}
