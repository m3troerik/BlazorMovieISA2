using Abc.Aids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aids;
[TestClass]
public class TypeExtensionTests : TestAids
{
    [TestInitialize]
    public void Initialize() => type = typeof(TypeExtension);

    [TestMethod]
    public void IsBoolTest()
    {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
        Assert.IsTrue(typeof(bool).IsBool());
        Assert.IsFalse(TypeExtension.IsBool(typeof(string)));
    }

    [TestMethod]
    public void IsBoolNullableTest()
    {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool?)));
    }

    [TestMethod]
    public void IsDateTest()
    {
        Assert.IsTrue(TypeExtension.IsDate(typeof(DateTime)));
        Assert.IsFalse(TypeExtension.IsDate(typeof(string)));
    }

    [TestMethod]
    public void IsStringTest()
    {
        Assert.IsTrue(TypeExtension.IsString(typeof(string)));
        Assert.IsFalse(TypeExtension.IsString(typeof(int)));
    }

    [DataRow(typeof(sbyte))]
    [DataRow(typeof(byte?))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(byte?))]
    [DataRow(typeof(int))]
    [DataRow(typeof(int?))]
    [TestMethod]
    public void IsNumericTest(Type t)
    {
        Assert.IsTrue(TypeExtension.IsNumeric(t));
        Assert.IsTrue(t.IsNumeric());
    }
}
