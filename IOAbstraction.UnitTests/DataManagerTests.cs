using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOAbstraction.DataFileRepository;
using IOAbstraction.DataManager.Model;
using IOAbstraction.DataTransformer;
using IOAbstraction.SystemFileOperationsManager;
using Moq;
using NUnit.Framework;

namespace IOAbstraction.UnitTests
{
    [TestFixture]
    public class DataManagerTests
    {
        private Mock<IDataFileRepository> m_DataFileRepositoryMock;
        private Mock<IDataTransformer> m_DataTransformerMock;
        private DataManager.DataManager m_Sut;

        [SetUp]
        public void SetUp()
        {
            m_DataFileRepositoryMock = new Mock<IDataFileRepository>();
            m_DataTransformerMock = new Mock<IDataTransformer>();
            m_Sut = new DataManager.DataManager(m_DataFileRepositoryMock.Object, m_DataTransformerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            m_Sut = null;
            m_DataFileRepositoryMock = null;
            m_DataTransformerMock = null;
        }

        [Test]
        public void GetAllData_ShouldGetAllData()
        {
            // Arrange
            var allDataText = "Mohamed,20,Accountant\r\nPatrick,26,Mechanical Engineer";

            var allData = new List<DataEntry>
            {
                new DataEntry("Mohamed", "20", "Accountant"),
                new DataEntry("Patrick", "26", "Mechanical Engineer")
            };

            m_DataFileRepositoryMock
                .Setup
                (
                    m => m.GetAllDataText()
                )
                .Returns(allDataText)
                .Verifiable();

            m_DataTransformerMock
                .Setup
                (
                    m => m.CombinedTextToDataEntries(
                        It.Is<string>(p => p == allDataText)
                    )
                )
                .Returns(allData)
                .Verifiable();

            // Act
            var actual = m_Sut.GetAllData();

            // Assert
            m_DataFileRepositoryMock
                .Verify
                (
                    m => m.GetAllDataText()
                );

            m_DataTransformerMock
                .Verify
                (
                    m => m.CombinedTextToDataEntries(allDataText)
                );

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("Mohamed", actual.ElementAt(0).Name);
            Assert.AreEqual("20", actual.ElementAt(0).Age);
            Assert.AreEqual("Accountant", actual.ElementAt(0).Profession);
            Assert.AreEqual("Patrick", actual.ElementAt(1).Name);
            Assert.AreEqual("26", actual.ElementAt(1).Age);
            Assert.AreEqual("Mechanical Engineer", actual.ElementAt(1).Profession);
        }

        [Test]
        public void AddNewDataEntry_ShouldAddNewDataEntry()
        {
            // Arrange
            var entry = new DataEntry("Mohamed", "20", "Accountant");
            var entryText = "Mohamed,20,Accountant";

            var allData = new List<DataEntry>
            {
                new DataEntry("Patrick", "26", "Mechanical Engineer")
            };

            m_DataTransformerMock
                .Setup
                (
                    m => m.DataEntryToText(
                        It.Is<DataEntry>(p => p == entry)
                    )
                )
                .Returns(entryText)
                .Verifiable();

            m_DataFileRepositoryMock
                .Setup
                (
                    m => m.AddNewDataEntryText
                    (
                        It.Is<string>(p => p == entryText)
                    )
                )
                .Verifiable();

            // Act
            m_Sut.AddNewDataEntry(entry);

            // Assert
            m_DataTransformerMock
                .Verify
                (
                    m => m.DataEntryToText(entry)
                );

            m_DataFileRepositoryMock
                .Verify
                (
                    m => m.AddNewDataEntryText(entryText)
                );
        }

        [Test]
        public void RemoveLastDataEntryText_RemoveLastDataEntry()
        {
            // Arrange
            m_DataFileRepositoryMock
                .Setup
                (
                    m => m.RemoveLastDataEntryText()
                )
                .Verifiable();

            // Act
            m_Sut.RemoveLastDataEntryText();

            // Assert
            m_DataFileRepositoryMock
                .Verify
                (
                    m => m.RemoveLastDataEntryText()
                );
        }
    }
}