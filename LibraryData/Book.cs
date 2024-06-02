using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }

        public Book(int id, string name)
        {
            this.BookID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return "ID: " + BookID + ", Title: " + Name;
        }

        public override int GetHashCode()
        {
            int hashId = BookID.GetHashCode();
            int hashName = Name.GetHashCode();
            return hashId ^ hashName;
        }
    }
}
