namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        /// <summary>
        /// Here we override the abstract method from Animal
        /// </summary>
        /// <returns></returns>
        public override string ProduceSound()
        {
            return "Woof!";
        }

    }
}
