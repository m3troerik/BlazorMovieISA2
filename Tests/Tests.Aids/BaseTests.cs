using System.Linq;

namespace Aids;

public abstract class BaseTests<TClass> : TestAids<TClass> where TClass : class, new()
{
    protected TClass obj;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        obj = new TClass();
    }

    [TestMethod]
    public void CanCreateTest() => Assert.IsNotNull(obj);

    [TestMethod]
    public void IsClassTestedTest()
    {
        var testMethods = GetType().GetMethods().Select(x => x.Name);
        var membersToTest = type.GetProperties().Select(x => x.Name).Concat(getMethods());
        foreach (var m in membersToTest)
        {
            if (!testMethods.Contains(m + "Test"))
                Assert.Inconclusive($"{m} is not tested");
        }
    }
}