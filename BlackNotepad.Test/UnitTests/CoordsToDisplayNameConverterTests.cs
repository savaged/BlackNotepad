using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.BlackNotepad.Converters;

namespace BlackNotepad.Test.UnitTests
{
    [TestClass]
    public class CoordsToDisplayNameConverterTests
    {
        [TestMethod]
        public void TestConvert()
        {
            var coords = (Column: 2, Line: 3);
            var converter = new CoordsToDisplayNameConverter();
            var result = converter.Convert(coords, typeof(string), null, null);
            Assert.AreEqual("Ln 3, Col 2", result);
        }
    }
}
