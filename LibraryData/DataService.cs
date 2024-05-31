using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class DataService
    {
        private DataRepository _dataRepository = null;

        public DataService(DataRepository dataRepository)
        {
            if (dataRepository == null)
                throw new ArgumentNullException(); 
            this._dataRepository = dataRepository ;
        }

        #region User

        public void AddUser(User User)
        {
            return _dataRepository.AddBook(User);
        }

        #endregion
        public Dictionary<int, Book> GetBooks() 
        { 
            return _dataRepository.GetBooks(); 
        }

        
    }
}
