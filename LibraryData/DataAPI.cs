using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public partial class DataAPI
    {
        public List<User> Users = new List<User> ();
        public Dictionary<int, Book> Catalog = new Dictionary<int, Book>();
        public List<State> States = new List<State> ();
    }
}
