using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.BlackNotepad.Converters;
using Savaged.BlackNotepad.Lookups;

namespace BlackNotepad.Test.UnitTests
{
    [TestClass]
    public class LineEndingEnumToDisplayNameConverterTests
    {
        [TestMethod]
        public void TestConvert()
        {
            var converter = new LineEndingEnumToDisplayNameConverter();
            var value = (string)converter.Convert(
                LineEndings.CRLF, typeof(string), null, null);
            Assert.AreEqual("Windows (CRLF)", value);
            value = (string)converter.Convert(
                LineEndings.LF, typeof(string), null, null);
            Assert.AreEqual("Mac (LF)", value);
            value = (string)converter.Convert(
                LineEndings.CR, typeof(string), null, null);
            Assert.AreEqual("Unix (CR)", value);
        }
    }
}
