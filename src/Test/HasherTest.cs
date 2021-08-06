using Hashio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class HasherTest
    {
        const string Field = "mypassword";

        [TestMethod]
        public void Hash_Method_Returns_A_Different_Hash_For_Same_field_Inserted ()
        {
            var hashOne = Hasher.Hash(Field);
            var hashTwo = Hasher.Hash(Field);

            Assert.AreEqual(95, hashOne.Length);
            Assert.AreEqual(95, hashTwo.Length);
            Assert.AreNotEqual(hashOne, hashTwo);

        }

        [TestMethod]
        public void Check_Method_returns_a_True_For_Same_Hash_Inserted ()
        {
            var hashGenerated = Hasher.Hash(Field);
            Assert.IsTrue(Hasher.Check(hashGenerated, Field));
        }
    }
}
