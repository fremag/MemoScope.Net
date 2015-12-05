using MemoScope.Core;
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
    }
}
