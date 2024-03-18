using ExtendedDatabase;
using NUnit.Framework;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private const string ValidUserName = "pesho123";
        private const long ValidId = 100001;

        [Test]
        public void Ctor_WithValidParameters_CreateNewInstance()
        {
            Person person = new Person(ValidId, ValidUserName);
            Assert.That(person, Is.Not.Null);
            Assert.That(person.Id, Is.EqualTo(ValidId));
            Assert.That(person.UserName, Is.EqualTo(ValidUserName));
        }
    }
}
