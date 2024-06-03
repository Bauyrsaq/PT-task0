using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Book(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return Id + ": " + Name;
        }

        public override int GetHashCode()
        {
            int hashId = Id.GetHashCode();
            int hashName = Name.GetHashCode();
            return hashId ^ hashName;
        }
    }
}
