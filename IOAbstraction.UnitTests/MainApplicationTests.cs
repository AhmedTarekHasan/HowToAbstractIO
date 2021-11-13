using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOAbstraction.DataFileRepository;
using IOAbstraction.DataManager;
using IOAbstraction.DataManager.Model;
using IOAbstraction.DataTransformer;
using IOAbstraction.SystemFileOperationsManager;
using Moq;
using NUnit.Framework;

namespace IOAbstraction.UnitTests
{
    [TestFixture]
    public class MainApplicationTests
    {
        private Mock<IDataManager> m_DataManagerMock;
        private MainApplication.MainApplication m_Sut;

        [SetUp]
        public void SetUp()
        {
            m_DataManagerMock = new Mock<IDataManager>();

            m_Sut = new MainApplication.MainApplication(m_DataManagerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            m_Sut = null;
            m_DataManagerMock = null;
        }

        [Test]
        public void GetAllToPresentInUi_ShouldGetAllDataIntoTextFormatToPresentInUi()
        {
            // Arrange
            var entries = new List<DataEntry>
            {
                new DataEntry("Mohamed", "20", "Accountant"),
                new DataEntry("Patrick", "26", "Mechanical Engineer")
            };

            var expected = new string[]
            {
                "Name: Mohamed, Age: 20, Profession: Accountant",
                "Name: Patrick, Age: 26, Profession: Mechanical Engineer",
            };

            m_DataManagerMock
                .Setup
                (
                    m => m.GetAllData()
                )
                .Returns(entries)
                .Verifiable();

            // Act
            var actual = m_Sut.GetAllToPresentInUi();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ShouldAddEntry()
        {
            // Arrange
            var entry = new DataEntry("Mohamed", "20", "Accountant");

            m_DataManagerMock
                .Setup
                (
                    m => m.AddNewDataEntry
                    (
                        It.Is<DataEntry>(p => p.Name == entry.Name && p.Age == entry.Age &&
                                              p.Profession == entry.Profession)
                    )
                )
                .Verifiable();

            // Act
            m_Sut.Add(entry);

            // Assert
            m_DataManagerMock
                .Verify
                (
                    m => m.AddNewDataEntry
                    (
                        It.Is<DataEntry>(p => p.Name == entry.Name && p.Age == entry.Age &&
                                              p.Profession == entry.Profession)
                    )
                );
        }

        [Test]
        public void Remove_ShouldRemoveLastEntry()
        {
            // Arrange

            m_DataManagerMock
                .Setup
                (
                    m => m.RemoveLastDataEntryText()
                )
                .Verifiable();

            // Act
            m_Sut.Remove();

            // Assert
            m_DataManagerMock
                .Verify
                (
                    m => m.RemoveLastDataEntryText()
                );
        }
    }
}