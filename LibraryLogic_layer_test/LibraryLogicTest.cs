// LibraryLogicTest.cs

using NUnit.Framework;
using LibraryLogic;
using Logic_layer_API;
using LibraryLogic_layer_test.Instrumentation;

namespace LibraryLogic_layer_test
{
    [TestFixture]
    public class LibraryLogicTests
    {
        private LibraryLogic_layer_API _libraryLogic;

        [SetUp]
        public void Initialize()
        {
            // Initialize the logic layer with the stub implementation of the data layer
            _libraryLogic = new LibraryLogic_layer(new LibraryDataAbstractFixture());
        }

        [Test]
        public void TestBorrowBook()
        {
            Assert.IsNotNull(_libraryLogic, "Library logic layer should be initialized.");
            _libraryLogic.BorrowBook(1, 1);
        }

        [Test]
        public void TestReturnBook()
        {
            Assert.IsNotNull(_libraryLogic, "Library logic layer should be initialized.");
            _libraryLogic.ReturnBook(1, 1);
        }
    }
}
