using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOAbstraction.DataManager.Model;
using NUnit.Framework;

namespace IOAbstraction.UnitTests
{
    [TestFixture]
    public class DataTransformerTests
    {
        private DataTransformer.DataTransformer m_Sut;

        [SetUp]
        public void SetUp()
        {
            m_Sut = new DataTransformer.DataTransformer();
        }

        [TearDown]
        public void TearDown()
        {
            m_Sut = null;
        }

        [Test]
        public void CombinedTextToDataEntries_ShouldConvertCombinedEntriesTextIntoDataEntries01()
        {
            // Arrange
            var combinedText = "Mohamed,20,Accountant\r\nPatrick,26,Mechanical Engineer";

            // Act
            var actual = m_Sut.CombinedTextToDataEntries(combinedText);

            // Assert
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("Mohamed", actual.ElementAt(0).Name);
            Assert.AreEqual("20", actual.ElementAt(0).Age);
            Assert.AreEqual("Accountant", actual.ElementAt(0).Profession);
            Assert.AreEqual("Patrick", actual.ElementAt(1).Name);
            Assert.AreEqual("26", actual.ElementAt(1).Age);
            Assert.AreEqual("Mechanical Engineer", actual.ElementAt(1).Profession);
        }

        [Test]
        public void CombinedTextToDataEntries_ShouldConvertCombinedEntriesTextIntoDataEntries02()
        {
            // Arrange
            var combinedText = "Mohamed,20,Accountant\r\n";

            // Act
            var actual = m_Sut.CombinedTextToDataEntries(combinedText);

            // Assert
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual("Mohamed", actual.ElementAt(0).Name);
            Assert.AreEqual("20", actual.ElementAt(0).Age);
            Assert.AreEqual("Accountant", actual.ElementAt(0).Profession);
        }

        [Test]
        public void CombinedTextToDataEntries_ShouldConvertCombinedEntriesTextIntoDataEntries03()
        {
            // Arrange
            var combinedText = "Mohamed,20,Accountant\r\n\r\nPatrick,26,Mechanical Engineer";

            // Act
            var actual = m_Sut.CombinedTextToDataEntries(combinedText);

            // Assert
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("Mohamed", actual.ElementAt(0).Name);
            Assert.AreEqual("20", actual.ElementAt(0).Age);
            Assert.AreEqual("Accountant", actual.ElementAt(0).Profession);
            Assert.AreEqual("Patrick", actual.ElementAt(1).Name);
            Assert.AreEqual("26", actual.ElementAt(1).Age);
            Assert.AreEqual("Mechanical Engineer", actual.ElementAt(1).Profession);
        }

        [Test]
        public void TextToDataEntry_ShouldConvertEntryTextToDataEntry01()
        {
            // Arrange
            var combinedText = "Mohamed,20,Accountant";

            // Act
            var actual = m_Sut.TextToDataEntry(combinedText);

            // Assert
            Assert.AreEqual("Mohamed", actual.Name);
            Assert.AreEqual("20", actual.Age);
            Assert.AreEqual("Accountant", actual.Profession);
        }

        [Test]
        public void TextToDataEntry_ShouldConvertEntryTextToDataEntry02()
        {
            // Arrange
            var combinedText = "";

            // Act
            var actual = m_Sut.TextToDataEntry(combinedText);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void TextToDataEntry_ShouldConvertEntryTextToDataEntry03()
        {
            // Arrange
            var combinedText = "Mohamed20Accountant";

            // Act
            var actual = m_Sut.TextToDataEntry(combinedText);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void DataEntryToText_ShouldConvertDataEntryToDataText()
        {
            // Arrange
            var entry = new DataEntry("Mohamed", "20", "Accountant");
            var expectedText = "Mohamed,20,Accountant";

            // Act
            var actual = m_Sut.DataEntryToText(entry);

            // Assert
            Assert.AreEqual(expectedText, actual);
        }
    }
}