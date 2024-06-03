using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }
    }
}
