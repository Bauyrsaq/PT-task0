using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;
using LibraryData.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryDataTest
{
    [TestClass]
    [DeploymentItem("LibraryDBTest.mdf")]
    public class DataTests
    {
        private static string connectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(IDataContext.CreateContext(connectionString));

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"LibraryDBTest.mdf";
            string _projectRootDir = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"Database file does not exist at: {_databaseFile}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public void UserTests()
        {
            int userId = 1;

            _dataRepository.AddUser(userId, "John", "Wick");

            IUser user = _dataRepository.GetUser(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.Id);
            Assert.AreEqual("John", user.Name);
            Assert.AreEqual("Wick", user.Surname);

            Assert.IsNotNull(_dataRepository.GetUsers());
            Assert.IsTrue(_dataRepository.GetUsersCount() > 0);

            Assert.ThrowsException<Exception>(() => _dataRepository.GetUser(userId + 2));

            _dataRepository.UpdateUser(userId, "Kate", "Baffen");

            IUser userUpdated = _dataRepository.GetUser(userId);

            Assert.IsNotNull(userUpdated);
            Assert.AreEqual(userId, userUpdated.Id);
            Assert.AreEqual("Kate", userUpdated.Name);
            Assert.AreEqual("Baffen", userUpdated.Surname);

            Assert.ThrowsException<Exception>(() => _dataRepository.UpdateUser(userId + 2,
                "Kate", "Baffen"));

            _dataRepository.DeleteUser(userId);
            Assert.ThrowsException<Exception>(() => _dataRepository.GetUser(userId));
            Assert.ThrowsException<Exception>(() => _dataRepository.DeleteUser(userId));
        }

        [TestMethod]
        public void BookTests()
        {
            int bookId = 2;

            _dataRepository.AddBook(bookId, "Cecil Martin", "Clean Code");

            IBook book = _dataRepository.GetBook(bookId);

            Assert.IsNotNull(book);
            Assert.AreEqual(bookId, book.Id);
            Assert.AreEqual("Cecil Martin", book.Author);
            Assert.AreEqual("Clean Code", book.Name);

            Assert.IsNotNull(_dataRepository.GetBooks());
            Assert.IsTrue(_dataRepository.GetBooksCount() > 0);

            Assert.ThrowsException<Exception>( () => _dataRepository.GetBook(12));

            _dataRepository.UpdateBook(bookId, "Aditya Y. Bhargava", "Grokking Algorithms");

            IBook bookUpdated = _dataRepository.GetBook(bookId);

            Assert.IsNotNull(bookUpdated);
            Assert.AreEqual(bookId, bookUpdated.Id);
            Assert.AreEqual("Aditya Y. Bhargava", bookUpdated.Author);
            Assert.AreEqual("Grokking Algorithms", bookUpdated.Name);

            Assert.ThrowsException<Exception>( () => _dataRepository.UpdateBook(12, "Aditya Y. Bhargava", "Grokking Algorithms"));

            _dataRepository.DeleteBook(bookId);
            Assert.ThrowsException<Exception>( () => _dataRepository.GetBook(bookId));
            Assert.ThrowsException<Exception>( () => _dataRepository.DeleteBook(bookId));
        }

        [TestMethod]
        public void StateTests()
        {
            int bookId = 3;
            int stateId = 3;

            _dataRepository.AddBook(bookId, "Stephen G. Kochan", "Programming in C");

            IBook book = _dataRepository.GetBook(bookId);

            _dataRepository.AddState(stateId, bookId, 20);

            IState state = _dataRepository.GetState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.Id);
            Assert.AreEqual(bookId, state.bookId);
            Assert.AreEqual(20, state.bookQuantity);

            Assert.IsNotNull(_dataRepository.GetStates());
            Assert.IsTrue(_dataRepository.GetStatesCount() > 0);

            Assert.ThrowsException<Exception>( () => _dataRepository.GetState(stateId + 2));

            Assert.ThrowsException<Exception>( () => _dataRepository.AddState(stateId, 13, 20));

            Assert.ThrowsException<Exception>( () => _dataRepository.AddState(stateId, bookId, -1));

            _dataRepository.UpdateState(stateId, bookId, 5);

            IState stateUpdated = _dataRepository.GetState(stateId);

            Assert.IsNotNull(stateUpdated);
            Assert.AreEqual(stateId, stateUpdated.Id);
            Assert.AreEqual(bookId, stateUpdated.bookId);
            Assert.AreEqual(5, stateUpdated.bookQuantity);

            Assert.ThrowsException<Exception>( () => _dataRepository.UpdateState(stateId + 2, bookId, 20));
            Assert.ThrowsException<Exception>( () => _dataRepository.UpdateState(stateId, 13, 20));
            Assert.ThrowsException<Exception>( () => _dataRepository.UpdateState(stateId, bookId, -12));

            _dataRepository.DeleteState(stateId);
            Assert.ThrowsException<Exception>( () => _dataRepository.GetState(stateId));
            Assert.ThrowsException<Exception>( () => _dataRepository.DeleteState(stateId));

            _dataRepository.DeleteBook(bookId);
        }

        [TestMethod]
        public void BorrowingTests()
        {
            int borrowingId = 4;
            int userId = 4;
            int bookId = 4;
            int stateId = 4;

            _dataRepository.AddBook(bookId, "Stephen G. Kochan", "Programming in C");
            _dataRepository.AddState(stateId, bookId, 20);
            _dataRepository.AddUser(userId, "John", "Wick");

            IBook book = _dataRepository.GetBook(bookId);
            IState state = _dataRepository.GetState(stateId);
            IUser user = _dataRepository.GetUser(userId);

            _dataRepository.AddBorrowing(borrowingId, userId, stateId);

            IBorrowing borrowing = _dataRepository.GetBorrowing(borrowingId);

            Assert.IsNotNull(borrowing);
            Assert.AreEqual(borrowingId, borrowing.Id);
            Assert.AreEqual(stateId, borrowing.stateId);
            Assert.AreEqual(userId, borrowing.userId);

            Assert.IsNotNull(_dataRepository.GetBorrowings());
            Assert.IsTrue(_dataRepository.GetBorrowingsCount() > 0);

            _dataRepository.UpdateBorrowing(borrowingId, userId, stateId, DateTime.Now, null);

            IBorrowing borrowingUpdated = _dataRepository.GetBorrowing(borrowingId);

            Assert.IsNotNull(borrowingUpdated);
            Assert.AreEqual(borrowingId, borrowingUpdated.Id);
            Assert.AreEqual(stateId, borrowingUpdated.stateId);
            Assert.AreEqual(userId, borrowingUpdated.userId);

            _dataRepository.DeleteBorrowing(borrowingId);
            _dataRepository.DeleteState(stateId);
            _dataRepository.DeleteBook(bookId);
            _dataRepository.DeleteUser(userId);
        }
    }
}
