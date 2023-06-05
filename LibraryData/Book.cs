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
        public string Author { get; set; }
        public string Name { get; set; }

        public Book(int id, string author, string name)
        {
            this.Id = id;
            this.Author = author;
            this.Name = name;
        }
    }
}
