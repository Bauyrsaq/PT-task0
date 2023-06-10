using LibraryPresentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest
{
    public interface IGenerator
    {
        void GenerateUserModels(IUserMasterViewModel viewModel);

        void GenerateBookModels(IBookMasterViewModel viewModel);

        void GenerateStateModels(IStateMasterViewModel viewModel);

        void GenerateBorrowingModels(IBorrowingMasterViewModel viewModel);
    }
}
