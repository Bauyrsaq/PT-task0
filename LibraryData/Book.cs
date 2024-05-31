using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Book(int id, string name)
        {
            Id = id; 
            Name = name;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Title: " + Name;
        }

        public override int GetHashCode()
        {
            int hashId = Id.GetHashCode();
            int hashName = Name.GetHashCode();
            return hashId ^ hashName;
        }
    }
}
