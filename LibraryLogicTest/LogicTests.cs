using LibraryData.API;
using LibraryData.Database;
using LibraryLogic.API;
using LibraryLogicTest.Mock;

namespace LibraryLogicTest
{
    [TestClass]
    public class LogicTests
    {
        //private readonly IDataRepository _dataRepository = new DataRepositoryMock();

        DataRepositoryMock _dataRepository = new DataRepositoryMock();


        [TestMethod]
        public void UserLogicTests()
        {
            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._dataRepository);

            userCrud.AddUser(1, "John", "Wick");

            IUserDTO user = userCrud.GetUser(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("John", user.Name);
            Assert.AreEqual("Wick", user.Surname);

            Assert.IsNotNull(userCrud.GetUsers());

            userCrud.UpdateUser(1, "Kate", "Baffen");

            IUserDTO updatedUser = userCrud.GetUser(1);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(1, updatedUser.Id);
            Assert.AreEqual("Kate", updatedUser.Name);
            Assert.AreEqual("Baffen", updatedUser.Surname);

            userCrud.DeleteUser(1);
        }

        [TestMethod]
        public void BookLogicTests()
        {
            IBookCRUD bookCrud = IBookCRUD.CreateBookCRUD(this._dataRepository);

            bookCrud.AddBook(1, "Cecil Martin", "Clean Code");

            IBookDTO book = bookCrud.GetBook(1);

            Assert.IsNotNull(book);
            Assert.AreEqual(1, book.Id);
            Assert.AreEqual("Cecil Martin", book.Author);
            Assert.AreEqual("Clean Code", book.Name);

            Assert.IsNotNull(bookCrud.GetBooks());

            bookCrud.UpdateBook(1, "Aditya Y. Bhargava", "Grokking Algorithms");

            IBookDTO updatedBook = bookCrud.GetBook(1);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(1, updatedBook.Id);
            Assert.AreEqual("Aditya Y. Bhargava", updatedBook.Author);
            Assert.AreEqual("Grokking Algorithms", updatedBook.Name);

            bookCrud.DeleteBook(1);
        }

        [TestMethod]
        public void StateLogicTests()
        {
            IBookCRUD bookCrud = IBookCRUD.CreateBookCRUD(this._dataRepository);
            bookCrud.AddBook(1, "Cecil Martin", "Clean Code");
            IBookDTO book = bookCrud.GetBook(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._dataRepository);

            stateCrud.AddState(1, book.Id, 12);

            IStateDTO state = stateCrud.GetState(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.Id);
            Assert.AreEqual(book.Id, state.bookId);
            Assert.AreEqual(12, state.bookQuantity);

            stateCrud.UpdateState(1, book.Id, 20);

            IStateDTO updatedState = stateCrud.GetState(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual(1, updatedState.Id);
            Assert.AreEqual(book.Id, updatedState.bookId);
            Assert.AreEqual(20, updatedState.bookQuantity);

            stateCrud.DeleteState(1);
            bookCrud.DeleteBook(1);
        }

        [TestMethod]
        public void BorrowingLogicTest()
        {
            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._dataRepository);
            userCrud.AddUser(1, "John", "Wick");
            IUserDTO user = userCrud.GetUser(1);

            IBookCRUD bookCrud = IBookCRUD.CreateBookCRUD(this._dataRepository);
            bookCrud.AddBook(1, "Cecil Martin", "Clean Code");
            IBookDTO book = bookCrud.GetBook(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._dataRepository);
            stateCrud.AddState(1, book.Id, 12);
            IStateDTO state = stateCrud.GetState(1);

            IBorrowingCRUD borrowingCrud = IBorrowingCRUD.CreateBorrowingCRUD(this._dataRepository);
            borrowingCrud.AddBorrowing(1, user.Id, state.Id, 15);
            IBorrowingDTO borrowing = borrowingCrud.GetBorrowing(1);

            Assert.IsNotNull(borrowing);
            Assert.AreEqual(1, borrowing.Id);
            Assert.AreEqual(user.Id, borrowing.userId);
            Assert.AreEqual(state.Id, borrowing.stateId);
            Assert.AreEqual(15, borrowing.bookQuantity);

            borrowingCrud.UpdateBorrowing(borrowing.Id, user.Id, state.Id, DateTime.Now, 5);

            IBorrowingDTO updatedBorrowing = borrowingCrud.GetBorrowing(borrowing.Id);

            Assert.IsNotNull(updatedBorrowing);
            Assert.AreEqual(user.Id, updatedBorrowing.userId);
            Assert.AreEqual(state.Id, updatedBorrowing.stateId);
            Assert.AreEqual(5, updatedBorrowing.bookQuantity);

            borrowingCrud.DeleteBorrowing(borrowing.Id);
            stateCrud.DeleteState(state.Id);
            bookCrud.DeleteBook(book.Id);
            userCrud.DeleteUser(user.Id);
        }
    }
}