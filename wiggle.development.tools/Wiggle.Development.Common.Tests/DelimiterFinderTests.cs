using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Wiggle.Development.Common.Tests
{
    [TestFixture]
    public class DelimiterFinderTests
    {
        private DelimiterFinder _delimiterFinder;

        [SetUp]
        public void SetUp()
        {
            _delimiterFinder = new DelimiterFinder();
        }

        [Test]
        public void TestDelimitersFound()
        {
            var sourceTexts = new []
            {
                null,
                string.Empty,
                "Text without delimiters",
                "Text with ##ONE## delimiter",
                "Text with ##ONE## and ##TWO## delimiters",
                "##d1####d2##"
            };

            var expectedValues = new[]
            {
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string> {"ONE"},
                new List<string> {"ONE", "TWO"},
                new List<string> {"d1", "d2"},
            };

            for (var i = 0; i < sourceTexts.Length; i++)
            {
                var result = _delimiterFinder.GetDelimiters(sourceTexts[i]);

                Assert.AreEqual(expectedValues[i], result, string.Format("Unexpected result for case " + i));
            }

        }
    }
}
