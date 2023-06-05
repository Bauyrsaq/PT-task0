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

            Assert.ThrowsException<Exception>( () => _dataRepository.GetUser(userId + 2));

            _dataRepository.UpdateUser(userId, "Kate", "Baffen");

            IUser userUpdated = _dataRepository.GetUser(userId);

            Assert.IsNotNull(userUpdated);
            Assert.AreEqual(userId, userUpdated.Id);
            Assert.AreEqual("Kate", userUpdated.Name);
            Assert.AreEqual("Baffen", userUpdated.Surname);

            Assert.ThrowsException<Exception>( () => _dataRepository.UpdateUser(userId + 2,
                "Kate", "Baffen"));

            _dataRepository.DeleteUser(userId);
            Assert.ThrowsException<Exception>( () => _dataRepository.GetUser(userId));
            Assert.ThrowsException<Exception>( () => _dataRepository.DeleteUser(userId));
        }
    }
}
