namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHp = 30;
        private const string PeshoName = "Pesho The Barbarian";
        private const int PeshoDamage = 100;
        private const int PeshoHP = 250;

        private const string IvanName = "Ivan The Invincible";
        private const int IvanDamage = 100;
        private const int IvanHP = 250;

        Warrior pesho;

        public void Setup()
        {
            pesho = new Warrior(PeshoName, PeshoDamage, PeshoHP);
        }

        [Test]
        public void Ctor_ValidProperties_CreatesInstance()
        {
            Warrior pesho = new Warrior(PeshoName, PeshoDamage, PeshoHP);
            Assert.That(pesho, Is.Not.Null);
            Assert.That(pesho.Name, Is.EqualTo(PeshoName));
            Assert.That(pesho.Damage, Is.EqualTo(PeshoDamage));
            Assert.That(pesho.HP, Is.EqualTo(PeshoHP));
        }

        [Test]
        public void Name_IsNull_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, PeshoDamage, PeshoHP));
        }

        [Test]
        public void Name_WhiteSpace_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", PeshoDamage, PeshoHP));
        }


        [Test]
        public void Damage_IsZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(PeshoName, 0, PeshoHP));
        }

        [Test]
        public void Damage_IsLessThanZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(PeshoName, -1, PeshoHP));
        }

        [Test]
        public void HP_IsLessThanZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(PeshoName, PeshoDamage, -1));
        }

        [Test]
        public void Attack_IsLessThanZero_ThrowsException()
        {
            Warrior dragan = new Warrior("Dragan", 100, 29);
            Assert.Throws<InvalidOperationException>(() =>  dragan.Attack(pesho));
        }

    }
}