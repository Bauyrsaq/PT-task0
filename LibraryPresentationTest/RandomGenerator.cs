using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel;
using LibraryPresentationTest.Mock;
using LibraryPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest
{
    internal class RandomGenerator : IGenerator
    {
        private readonly IErrorInformer _informer = new TextErrorInformer();

        public void GenerateUserModels(IUserMasterViewModel viewModel)
        {
            IUserModelOperation operation = IUserModelOperation.CreateModelOperation(new UserCRUDMock());

            for (int i = 1; i <= 10; i++)
            {
                viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(i, RandomString(10), RandomString(10), operation, _informer));
            }
        }

        public void GenerateBookModels(IBookMasterViewModel viewModel)
        {
            IBookModelOperation operation = IBookModelOperation.CreateModelOperation(new BookCRUDMock());

            for (int i = 1; i <= 10; i++)
            {
                viewModel.Books.Add(IBookDetailViewModel.CreateViewModel(i, RandomString(10), RandomString(10), operation, _informer));
            }
        }

        public void GenerateStateModels(IStateMasterViewModel viewModel)
        {
            IStateModelOperation operation = IStateModelOperation.CreateModelOperation(new StateCRUDMock());

            for (int i = 1; i <= 10; i++)
            {
                viewModel.States.Add(IStateDetailViewModel.CreateViewModel(i, i, RandomNumber<int>(2), operation, _informer));
            }
        }

        public void GenerateBorrowingModels(IBorrowingMasterViewModel viewModel)
        {
            IBorrowingModelOperation operation = IBorrowingModelOperation.CreateModelOperation(new BorrowingCRUDMock());

            for (int i = 1; i <= 10; i++)
            {
                viewModel.Borrowings.Add(IBorrowingDetailViewModel.CreateViewModel(i, i, i, DateTime.Now, RandomNumber<int>(1), operation, _informer));
            }
        }

        private string RandomString(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var randomText = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }

        private string RandomStringWithNumber(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var randomText = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }

        private string RandomEmail()
        {
            return string.Format("{0}@{1}.com", RandomStringWithNumber(10), RandomString(5));
        }

        private T RandomNumber<T>(int length) where T : struct, IComparable
        {
            if (length <= 0)
                throw new ArgumentException("Number of digits must be positive.");

            Random random = new Random();

            T maxNumber = (T)Convert.ChangeType(Math.Pow(10, length), typeof(T));

            T randomNumber = (T)Convert.ChangeType(
                random.Next(
                    Convert.ToInt32(Math.Pow(10, length - 1)),
                    Convert.ToInt32(maxNumber)
                ), typeof(T)
            );

            return randomNumber;
        }

        private DateTime RandomDate()
        {
            Random random = new Random();

            DateTime date = new DateTime(1900, 1, 1);

            int range = (DateTime.Today - date).Days;

            return date.AddDays(random.Next(range))
                .AddHours(random.Next(24))
                .AddMinutes(random.Next(60))
                .AddSeconds(random.Next(60));
        }

        private int RandomPEGI()
        {
            Random random = new Random();

            List<int> pegiRange = new List<int>() { 3, 7, 12, 16, 18 };

            return random.Next(pegiRange.Count);
        }
    }
}
