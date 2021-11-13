using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOAbstraction.DataFileRepository;
using IOAbstraction.SystemFileOperationsManager;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace IOAbstraction.UnitTests
{
    [TestFixture]
    public class DataFileRepositoryTests
    {
        private const string DummyDataFilePath = "This is a dummy path for testing";

        private Mock<ISystemFileOperationsManager> m_SystemFileOperationsManagerMock;
        private DataFileRepository.DataFileRepository m_Sut;

        [SetUp]
        public void SetUp()
        {
            m_SystemFileOperationsManagerMock = new Mock<ISystemFileOperationsManager>();

            m_Sut = new DataFileRepository.DataFileRepository(m_SystemFileOperationsManagerMock.Object,
                DummyDataFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            m_Sut = null;
            m_SystemFileOperationsManagerMock = null;
        }

        [Test]
        public void GetAllDataText_ShouldReturnAllData()
        {
            // Arrange
            var text = "This is the sample text";

            m_SystemFileOperationsManagerMock
                .Setup
                (
                    m => m.ReadAllText(It.Is<string>(p => p == DummyDataFilePath))
                )
                .Returns(text)
                .Verifiable();

            // Act
            var actual = m_Sut.GetAllDataText();

            // Assert
            m_SystemFileOperationsManagerMock
                .Verify
                (
                    m => m.ReadAllText(DummyDataFilePath)
                );

            Assert.AreEqual(text, actual);
        }

        [TestCase(
            "Mohamed,20,Accountant",
            "Ahmed,36,Software Engineer",
            "Mohamed,20,Accountant" + "\r\n" + "Ahmed,36,Software Engineer",
            TestName = "Test Case 01")]
        [TestCase(
            "Mohamed,20,Accountant\r\n",
            "Ahmed,36,Software Engineer",
            "Mohamed,20,Accountant" + "\r\n" + "Ahmed,36,Software Engineer",
            TestName = "Test Case 02")]
        public void AddNewDataEntryText_ShouldAddDataInCorrectFormat(string existingData, string input, string expected)
        {
            // Arrange
            m_SystemFileOperationsManagerMock
                .Setup
                (
                    m => m.ReadAllText(It.Is<string>(p => p == DummyDataFilePath))
                )
                .Returns(existingData)
                .Verifiable();

            m_SystemFileOperationsManagerMock
                .Setup
                (
                    m => m.WriteAllText
                    (
                        It.Is<string>(p => p == DummyDataFilePath),
                        It.Is<string>(p => p == expected)
                    )
                )
                .Verifiable();

            // Act
            m_Sut.AddNewDataEntryText(input);

            // Assert
            m_SystemFileOperationsManagerMock
                .Verify
                (
                    m => m.ReadAllText(DummyDataFilePath)
                );

            m_SystemFileOperationsManagerMock
                .Verify
                (
                    m => m.WriteAllText
                    (
                        DummyDataFilePath,
                        expected
                    )
                );
        }

        [Test]
        public void RemoveLastDataEntryText_ShouldRemoveTheLastLine()
        {
            // Arrange
            var lines = new[] { "Line 1", "Line 2", "Line 3" };
            var expected = new[] { "Line 1", "Line 2" };

            m_SystemFileOperationsManagerMock
                .Setup
                (
                    m => m.ReadAllLines(It.Is<string>(p => p == DummyDataFilePath))
                )
                .Returns(lines)
                .Verifiable();

            m_SystemFileOperationsManagerMock
                .Setup
                (
                    m => m.WriteAllLines
                    (
                        It.Is<string>(p => p == DummyDataFilePath),
                        It.Is<IEnumerable<string>>(
                            p => p.Count() == 2 &&
                                 p.ElementAt(0) == expected[0] &&
                                 p.ElementAt(1) == expected[1])
                    )
                )
                .Verifiable();

            // Act
            m_Sut.RemoveLastDataEntryText();

            // Assert
            m_SystemFileOperationsManagerMock
                .Verify
                (
                    m => m.ReadAllLines(DummyDataFilePath)
                );

            m_SystemFileOperationsManagerMock
                .Verify
                (
                    m => m.WriteAllLines
                    (
                        DummyDataFilePath,
                        It.Is<IEnumerable<string>>(
                            p => p.Count() == 2 &&
                                 p.ElementAt(0) == expected[0] &&
                                 p.ElementAt(1) == expected[1])
                    )
                );
        }
    }
}