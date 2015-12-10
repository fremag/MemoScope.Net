using MemoScope.Core;
using MemoScope.Core.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestFixture]
    public class TypeHelpersTests
    {
        [Test]
        public void RealFieldNameTest()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>() {
                ["aaaaa"] = "aaaaa",
                ["<aaaa>k__BackingField"] = "aaaa [*]"
            };

            foreach(var field in fields)
            {
                Assert.That(TypeHelpers.RealName(field.Key), Is.EqualTo(field.Value));
            }
        }
        
        [Test]
        public void TypeAliasTest()
        {
            List<TypeAlias> typeAliases = new List<TypeAlias>();
            typeAliases.Add(new TypeAlias { OldTypeName = "System.Int16", NewTypeName = "int" });
            typeAliases.Add(new TypeAlias { OldTypeName = "System.Boolean", NewTypeName = "bool" });
            typeAliases.Add(new TypeAlias { OldTypeName = "System.Object", NewTypeName = "object" });
            typeAliases.Add(new TypeAlias { OldTypeName = "System.Collections.Generic", NewTypeName = "sys.col.gen" });

            Dictionary<string, string> fields = new Dictionary<string, string>()
            {
                ["aaaaa"] = "aaaaa",
                ["System.Object"] = "object",
                ["System.Collections.Generic.List<System.WeakReference>"] = "sys.col.gen.List<System.WeakReference>",
                ["System.Collections.Generic.List<Tuple<System.Object,System.Boolean>>"] = "sys.col.gen.List<Tuple<object,bool>>"
            };

            foreach (var field in fields)
            {
                string newTypeName = TypeHelpers.ManageAlias(field.Key, typeAliases);
                Assert.That(newTypeName, Is.EqualTo(field.Value));
            }
        }
    }
}
