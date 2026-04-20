using Abc.Aids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aids;
[TestClass]
public class PropertyAdapterTests : BaseTests<PropertyAdapter>
{
    private class testClass
    {
        public int? IntProp { get; set; }
        public string StringProp { get; set; }
    }

    private testClass item;
    private string propName = nameof(testClass.IntProp);
    private PropertyAdapter oStr;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        item = new testClass();
        obj = new PropertyAdapter(item, propName);
        oStr = new PropertyAdapter(item, nameof(testClass.StringProp));
    }
    [TestMethod]
    public void ItemTypeTest() => areEqual(typeof(testClass), obj.ItemType);

    [TestMethod]
    public void ItemTest() => areSame(item, obj.Item);

    [TestMethod]
    public void PropInfoTest() => areEqual(propName, obj.PropInfo.Name);

    [TestMethod]
    public void PropTypeTest()
    {
        areEqual(typeof(int?), obj.PropType);
        areEqual(typeof(string), oStr.PropType);
    }

    [TestMethod]
    public void UnderlyingTypeTest()
    {
        areEqual(typeof(int), obj.UnderlyingType);
        areEqual(typeof(string), oStr.UnderlyingType);
    }

    [TestMethod]
    public void PropValueTest()
    {
        areEqual(null, obj.PropValue);
        areEqual(null, oStr.PropValue);
    }

    [TestMethod]
    public void SetValueTest()
    {
        var i = GetRandom.Int32();
        var s = GetRandom.String();
        obj.SetValue(i);
        oStr.SetValue(s);

        areEqual(i, item.IntProp);
        areEqual(s, item.StringProp);
        areEqual(obj.PropValue, item.IntProp);
        areEqual(oStr.PropValue, item.StringProp);
    }
}