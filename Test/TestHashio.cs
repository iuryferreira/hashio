using Hash;
using NUnit.Framework;

namespace Test
{

    [TestFixture]
    public class TestHashio
    {
        private string field;
        private HashingOptions options;
        private Hashio hashio;

        [SetUp]
        public void SetUp ()
        {
            field = "Testing";
            hashio = new Hashio();
            options = new HashingOptions();
        }
        [Test]
        public void Hash_method_returns_a_diferent_hash_for_same_field_inserted ()
        {
            Assert.AreNotEqual(hashio.Hash(field), hashio.Hash(field));
        }

        [Test]
        public void Hash_method_returns_a_true_for_same_hash_inserted ()
        {
            var hashGenerated = hashio.Hash(field);
            Assert.True(hashio.Check(hashGenerated, field));
        }


    }
}