using LibraryLogic.API;
using LibraryPresentation.Model;
using LibraryPresentation.ViewModel;
using LibraryPresentation;
using LibraryPresentationTest.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest
{
    [TestClass]
    public class PresentationTests
    {

        [TestMethod]
        public void UserMasterViewModelTests()
        {
            IUserCRUD userCrud = new UserCRUDMock();

            IUserModelOperation operation = IUserModelOperation.CreateModelOperation(userCrud);

            IUserMasterViewModel viewModel = IUserMasterViewModel.CreateViewModel(operation);

            viewModel.Name = "John";
            viewModel.Surname = "Kowalski";

            Assert.IsNotNull(viewModel.CreateUser);
            Assert.IsNotNull(viewModel.RemoveUser);

            Assert.IsTrue(viewModel.CreateUser.CanExecute(null));

            Assert.IsTrue(viewModel.RemoveUser.CanExecute(null));
        }

        [TestMethod]
        public void UserDetailViewModelTests()
        {
            IUserCRUD userCrud = new UserCRUDMock();

            IUserModelOperation operation = IUserModelOperation.CreateModelOperation(userCrud);

            IUserDetailViewModel detail = IUserDetailViewModel.CreateViewModel(1, "John", "Kowalski", operation);

            Assert.AreEqual(1, detail.Id);
            Assert.AreEqual("John", detail.Name);
            Assert.AreEqual("Kowalski", detail.Surname);

            Assert.IsTrue(detail.UpdateUser.CanExecute(null));
        }

        [TestMethod]
        public void BookMasterViewModelTests()
        {
            IBookCRUD BookCRUDMock = new BookCRUDMock();

            IBookModelOperation operation = IBookModelOperation.CreateModelOperation(BookCRUDMock);

            IBookMasterViewModel master = IBookMasterViewModel.CreateViewModel(operation);

            master.Author = "Tramp";
            master.Name = "ABCD";

            Assert.IsNotNull(master.CreateBook);
            Assert.IsNotNull(master.RemoveBook);

            Assert.IsTrue(master.CreateBook.CanExecute(null));

            Assert.IsTrue(master.RemoveBook.CanExecute(null));
        }

        [TestMethod]
        public void BookDetailViewModelTests()
        {
            IBookCRUD BookCRUDMock = new BookCRUDMock();

            IBookModelOperation operation = IBookModelOperation.CreateModelOperation(BookCRUDMock);

            IBookDetailViewModel detail = IBookDetailViewModel.CreateViewModel(1, "Tramp", "ABCD", operation);

            Assert.AreEqual(1, detail.Id);
            Assert.AreEqual("Tramp", detail.Author);
            Assert.AreEqual("ABCD", detail.Name);

            Assert.IsTrue(detail.UpdateBook.CanExecute(null));
        }

        [TestMethod]
        public void StateMasterViewModelTests()
        {
            IStateCRUD StateCRUDMock = new StateCRUDMock();

            IStateModelOperation operation = IStateModelOperation.CreateModelOperation(StateCRUDMock);

            IStateMasterViewModel master = IStateMasterViewModel.CreateViewModel(operation);

            master.bookId = 1;
            master.bookQuantity = 1;

            Assert.IsNotNull(master.CreateState);
            Assert.IsNotNull(master.RemoveState);

            Assert.IsTrue(master.CreateState.CanExecute(null));

            master.bookQuantity = -1;

            Assert.IsFalse(master.CreateState.CanExecute(null));

            Assert.IsTrue(master.RemoveState.CanExecute(null));
        }

        [TestMethod]
        public void StateDetailViewModelTests()
        {
            IStateCRUD StateCRUDMock = new StateCRUDMock();

            IStateModelOperation operation = IStateModelOperation.CreateModelOperation(StateCRUDMock);

            IStateDetailViewModel detail = IStateDetailViewModel.CreateViewModel(1, 1, 1, operation);

            Assert.AreEqual(1, detail.Id);
            Assert.AreEqual(1, detail.bookId);
            Assert.AreEqual(1, detail.bookQuantity);

            Assert.IsTrue(detail.UpdateState.CanExecute(null));
        }

        [TestMethod]
        public void BorrowingMasterViewModelTests()
        {
            IBorrowingCRUD BorrowingCRUDMock = new BorrowingCRUDMock();

            IBorrowingModelOperation operation = IBorrowingModelOperation.CreateModelOperation(BorrowingCRUDMock);

            IBorrowingMasterViewModel master = IBorrowingMasterViewModel.CreateViewModel(operation);

            master.userId = 1;
            master.stateId = 1;

            Assert.IsNotNull(master.PurchaseBorrowing);
            Assert.IsNotNull(master.ReturnBorrowing);
            Assert.IsNotNull(master.SupplyBorrowing);
            Assert.IsNotNull(master.RemoveBorrowing);

            Assert.IsTrue(master.PurchaseBorrowing.CanExecute(null));
            Assert.IsTrue(master.ReturnBorrowing.CanExecute(null));
            Assert.IsFalse(master.SupplyBorrowing.CanExecute(null));

            master.bookQuantity = 1;

            Assert.IsTrue(master.SupplyBorrowing.CanExecute(null));

            Assert.IsTrue(master.RemoveBorrowing.CanExecute(null));
        }

        [TestMethod]
        public void BorrowingDetailViewModelTests()
        {
            IBorrowingCRUD BorrowingCRUDMock = new BorrowingCRUDMock();

            IBorrowingModelOperation operation = IBorrowingModelOperation.CreateModelOperation(BorrowingCRUDMock);

            IBorrowingDetailViewModel detail = IBorrowingDetailViewModel.CreateViewModel(1, 1, 1, new DateTime(2001, 1, 1), null, operation);

            Assert.AreEqual(1, detail.Id);
            Assert.AreEqual(1, detail.userId);
            Assert.AreEqual(1, detail.stateId);
            Assert.AreEqual(new DateTime(2001, 1, 1), detail.Date);

            Assert.IsTrue(detail.UpdateBorrowing.CanExecute(null));
        }

        [TestMethod]
        public void DataRandomGenerationMethodTests()
        {
            IGenerator randomGenerator = new RandomGenerator();

            IUserCRUD UserCRUDMock = new UserCRUDMock();
            IUserModelOperation userOperation = IUserModelOperation.CreateModelOperation(UserCRUDMock);
            IUserMasterViewModel userViewModel = IUserMasterViewModel.CreateViewModel(userOperation);

            IBookCRUD BookCRUDMock = new BookCRUDMock();
            IBookModelOperation BookOperation = IBookModelOperation.CreateModelOperation(BookCRUDMock);
            IBookMasterViewModel BookViewModel = IBookMasterViewModel.CreateViewModel(BookOperation);


            IStateCRUD StateCRUDMock = new StateCRUDMock();
            IStateModelOperation stateOperation = IStateModelOperation.CreateModelOperation(StateCRUDMock);
            IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation);

            IBorrowingCRUD BorrowingCRUDMock = new BorrowingCRUDMock();
            IBorrowingModelOperation BorrowingOperation = IBorrowingModelOperation.CreateModelOperation(BorrowingCRUDMock);
            IBorrowingMasterViewModel BorrowingViewModel = IBorrowingMasterViewModel.CreateViewModel(BorrowingOperation);

            randomGenerator.GenerateUserModels(userViewModel);
            randomGenerator.GenerateBookModels(BookViewModel);
            randomGenerator.GenerateStateModels(stateViewModel);
            randomGenerator.GenerateBorrowingModels(BorrowingViewModel);

            Assert.AreEqual(10, userViewModel.Users.Count);
            Assert.AreEqual(10, BookViewModel.Books.Count);
            Assert.AreEqual(10, stateViewModel.States.Count);
            Assert.AreEqual(10, BorrowingViewModel.Borrowings.Count);
        }
    }
}
