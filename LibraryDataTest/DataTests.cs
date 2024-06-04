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
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string _DBPath = Path.Combine(_projectRootDir.ToString(), _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public void UserTests()
        {
            int userId = 1;

            

        }
    }
}
