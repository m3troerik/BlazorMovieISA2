using System.Reflection;

namespace Abc.Tests.Aids
{
    public abstract class TestAids<TClass> where TClass : class, new()
    {
        protected TClass obj;
        protected const BindingFlags publicDeclared = BindingFlags.Public
            | BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Static;

        protected static IEnumerable<string> getProperties()
            => Abc.Aids.GetType.PropertyNames<TClass>(publicDeclared);

        protected static IEnumerable<string> getMethods()
            => Abc.Aids.GetType.MethodNames<TClass>(publicDeclared, false);
    }
}


