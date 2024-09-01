using System.Diagnostics;

namespace QuotesApiV2.Unit.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Debug.WriteLine("I should see this before a test runs");
        }

        [TearDown]
        public void Teardown()
        {
            Debug.WriteLine("I should see this after a test runs");
        }

        [Test]
        [Order(1)]
        public void Test1()
        {

            Debug.WriteLine("From test method one, should come second due to order attribute");

            Assert.IsTrue(true);
            
        }

        [Test]
        [Order(2)]
        public void Test2()
        {

            Debug.WriteLine("From test method two, should come last due to order attribute");

            Assert.IsTrue(true);

        }

        [Test]
        [Order(0)]
        public void Test3()
        {

            Debug.WriteLine("From test method three, should come first due to order attribute");

            Assert.IsTrue(true);

        }
    }
}