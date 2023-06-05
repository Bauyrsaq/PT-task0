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
            string _projectRootDir = Directory.GetCurrentDirectory();
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"Database file does not exist at: {_projectRootDir}");
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

        }
    }
}
