using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Alfa Romeo";
        private const string Model = "Giulia";
        private const double Consumption = 7.0;
        private const double FuelCapacity = 50;
        private Car alfa;

        [SetUp]
        public void Setup()
        {
            alfa = new Car(Make, Model, Consumption, FuelCapacity);
        }

        [Test]
        public void Ctor_CorrectParameters_CreatesNewInstance()
        {
            Car newAlfa = new Car(Make, Model, Consumption, FuelCapacity);
            Assert.That(newAlfa, Is.Not.Null);
            Assert.That(newAlfa.Make, Is.EqualTo(Make));
            Assert.That(newAlfa.Model, Is.EqualTo(Model));
            Assert.That(newAlfa.FuelConsumption, Is.EqualTo(Consumption));
            Assert.That(newAlfa.FuelCapacity, Is.EqualTo(FuelCapacity));
            Assert.That(newAlfa.FuelAmount, Is.EqualTo(0));
        }


        [Test]
        public void Make_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(null, Model, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Make_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(string.Empty, Model, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }


        [Test]
        public void Model_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, null, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Model_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, string.Empty, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void FuelConsumption_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, Make, 0, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }


        [Test]
        public void FuelCapacity_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, Make, Consumption, 0));
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_HappyPath_FuelAddedToTank()
        {
            double amountOfFuel = FuelCapacity - 1;
            alfa.Refuel(amountOfFuel);

            Assert.That(alfa.FuelAmount, Is.EqualTo(amountOfFuel));
        }

        [Test]
        public void Refuel_TankOverFlow_FuelAddedToTank()
        {
            double amountOfFuel = FuelCapacity + 1;
            alfa.Refuel(amountOfFuel);
            Assert.That(alfa.FuelAmount, Is.EqualTo(FuelCapacity));
        }


        [Test]
        public void Refuel_RefuelZeroOrLessLiters_FuelAddedToTank()
        {
            Assert.Throws<ArgumentException>(() => alfa.Refuel(0));
            Assert.Throws<ArgumentException>(() => alfa.Refuel(-1));
        }

        [Test]
        public void Drive_HappyPath_ReducesFuelAmount()
        {
            // 1. Setup
            double distance = 20;
            alfa.Refuel(FuelCapacity);
            double fuelNeeded = (distance / 100) * Consumption;
            double expectedFuelAmount = alfa.FuelAmount - fuelNeeded;

            // 2. Action
            alfa.Drive(distance);

            // 3. Assert
            Assert.That(alfa.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        public void Drive_NotEnoughFuel_ReducesFuelAmount()
        {

            double distance = 20;
            double fuelNeeded = (distance / 100) * Consumption;
            double expectedFuelAmount = alfa.FuelAmount - fuelNeeded;

            var exception = Assert.Throws<InvalidOperationException>(()=> alfa.Drive(distance));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));

        }
    }
}