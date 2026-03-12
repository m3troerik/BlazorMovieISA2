using Abc.Data;

namespace Abc.Tests.Data
{
    [TestClass]
    public abstract class BaseTests<TClass> where TClass : class, new()
    {
        private TClass obj;
        // checks whether object can be created successfully
        [TestInitialize] public void Initialize() => obj = new TClass();
        [TestMethod]
        public void CanCreateTest() => Assert.IsNotNull(obj);

        [TestMethod]
        public void IsClassCorrectTest()
        {

            var className = typeof(TClass).Name;
            var testClassName = GetType().Name;
            Assert.AreEqual(className, testClassName);


        }

        [TestMethod]
        public void IsClassTestedTest()
        {

            var className = typeof(TClass).Name;
            var testClassName = GetType().Name;
            var testMethods = GetType().GetMethods();
            var classMembers = typeof(TClass).GetMembers();


        }

    }
}


